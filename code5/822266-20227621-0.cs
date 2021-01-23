    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class Book
            {
                public int UidBook { get; set; }
                public int UidCategory { get; set; }
                public int Score { get; set; }
            }
    
            public class Category
            {
                public int UidCategory { get; set; }
                public int Score { get; set; }
            }
    
            public class Author
            {
                public int UidAuthor { get; set; }
                public int Score { get; set; }
            }
    
            public class AuthorBook
            {
                public int UidAuthor { get; set; }
                public int UidBook { get; set; }
            }
    
            static void Main(string[] args)
            {
                List<Category> categories = new List<Category>
                {
                    new Category() { UidCategory = 1, Score = 25 },
                    new Category() { UidCategory = 2, Score = 50 }
                };
    
                List<Book> books = new List<Book>
                {         
                    new Book() { UidBook = 1, UidCategory = 1, Score = 44 },
                    new Book() { UidBook = 2, UidCategory = 2, Score = 88 },
                    new Book() { UidBook = 3, UidCategory = 1, Score = 99 },
                    new Book() { UidBook = 4, UidCategory = 2, Score = 66 }
                };
    
                List<Author> authors = new List<Author>
                {
                    new Author() { UidAuthor = 1, Score = 301 },
                    new Author() { UidAuthor = 2, Score = 501 },
                    new Author() { UidAuthor = 3, Score = 601 }
                };
    
                List<AuthorBook> authorBooks = new List<AuthorBook>
                {
                    new AuthorBook() { UidAuthor = 1, UidBook = 1 },
                    new AuthorBook() { UidAuthor = 1, UidBook = 2 },
                    new AuthorBook() { UidAuthor = 2, UidBook = 3 },
                    new AuthorBook() { UidAuthor = 3, UidBook = 4 }
                };
    
                var result = from book in books
                            join category in categories on book.UidCategory equals category.UidCategory
                            join authorBook in authorBooks on book.UidBook equals authorBook.UidBook
                            join author in authors on authorBook.UidAuthor equals author.UidAuthor
                            group new { book, category, authorBook, author } by book.UidBook into groupedResult
                            select new
                            {
                                UidBook = groupedResult.Key,
                                Score   = groupedResult.First().book.Score + 
                                          groupedResult.First().category.Score +
                                          groupedResult.Sum(s => s.author.Score)
                            };
    
                foreach (var item in result)
                {
                    Console.WriteLine("{0} - {1}", item.UidBook, item.Score);
                }
    
                Console.Read();
            }
        }
    }
