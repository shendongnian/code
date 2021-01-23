    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Change array to a list, this allows me to add books to my collection without specifing indexes
                //See http://www.dotnetperls.com/list
                List<Book> books = new List<Book>();
    
                //I've changed the way you add books, now you declare a new book, and within it you declare a new person which is now a author of that new book
                books.Add(new Book("Moby Dick", new Person("Herman Melville", 72)));
                books.Add(new Book("The Creeping", new Person("Alexandra Sirowy", null)));
    
                //Use a foreach loop to iterate through the list printing the summary to each
                foreach (var book in books)
                {
                    Console.WriteLine(book.Summary);
                }
    
                //Exit
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
    
    class Person : IComparable
    {
        //Some syntax change here, people may disagree on my variable names
        private int? _age;
        private string _name;
    
        //Changed default constructor to accept age but made the age nullable(if you don't know the age of the person you can pass in null)
        //http://www.dotnetperls.com/nullable-int
        public Person(string name, int? age)
        {
            Name = name;
            Age = age;
        }
           
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    
        public int? Age
        {
            get { return _age; }
            set { _age = value; }
        }
    
        //Hmmm don't know about this are you sure you want to use name as the primary key, 
        //what if you have two people with the same names but different ages, are they the same person?
        public int CompareTo(Object obj)
        {
            return Name.CompareTo(((Person)obj).Name);
        }
    }
    
    class Book
    {
        //Made these auto properties
        public string Title { get; set; }
        public Person Author { get; set; }
    
        //Now the book default constructor accepts a author, this forces you(when using this function to create a new book)
        //To specifiy a person as a author
        public Book(string title, Person author)
        {
            Author = author;
            Title = title;
        }
    
        //Used "Darren Young" code, this is much better
        public string Summary
        {
            get
            {
                return string.Format("{0}, {1}, {2}", Title, Author.Name, Author.Age);
            }
        }
    }
