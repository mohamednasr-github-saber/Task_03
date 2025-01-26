using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Book
    {
        private string title;
        private string author;
        private string isbn;
        private bool isAvailable;

        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.isAvailable = true;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
        }

        public string GetAuthor()
        {
            return author;
        }

        public void SetAuthor(string value)
        {
            author = value;
        }

        public string GetISBN()
        {
            return isbn;
        }

        public void SetISBN(string value)
        {
            isbn = value;
        }

        public bool GetIsAvailable()
        {
            return isAvailable;
        }

        public void SetIsAvailable(bool value)
        {
            isAvailable = value;
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void BorrowBook(string query)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle().ToLower().Contains(query.ToLower()))
                {
                    if (book.GetIsAvailable())
                    {
                        book.SetIsAvailable(false);
                        Console.WriteLine($"You have borrowed '{book.GetTitle()}'.");
                    }
                    else
                    {
                        Console.WriteLine($"'{book.GetTitle()}' is already borrowed.");
                    }
                    return;
                }
            }
            Console.WriteLine($"Book '{query}' not found in the library.");
        }

        public void ReturnBook(string query)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.GetTitle().ToLower().Contains(query.ToLower()))
                {
                    if (!book.GetIsAvailable())
                    {
                        book.SetIsAvailable(true);
                        Console.WriteLine($"You have returned '{book.GetTitle()}'.");
                    }
                    else
                    {
                        Console.WriteLine($"'{book.GetTitle()}' was not borrowed.");
                    }
                    return;
                }
            }
            Console.WriteLine($"Book '{query}' not found in the library.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter");

            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter");

            Console.ReadLine();
        }
    }
}
