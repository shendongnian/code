    using System;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("5.xml");
            var books = doc.Descendants("book");
            foreach (var book in books)
            {
                string title = book.Element("title").Value;
                string publisher = book.Element("publisher").Value;
                string description = book.Element("description").Value;
                string published = book.Element("published").Value;
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", title, publisher, description, published);
            }
        }
    }
