    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
    
            private static void Main(string[] args)
            {
                const string title = "The title of the document";
                const string press = "The press of the document";
                const string author = "Some author of the document";
                const int siteCounter = 10;
                Document w = new Book(title, press, siteCounter, author, null);
    
                List<Document> docList = new List<Document>();
    
                try
                {
                    docList.Add(w);
                }
                catch (TitleExistException e)
                {
                    Console.WriteLine(e);
    
                }
    
                DisplayListOfDocuments(docList);
            }
    
            public static void DisplayListOfDocuments(List<Document> docList)
            {
                Console.WriteLine("List");
    
                Console.WriteLine(docList.Count);
                foreach (Document p in docList)
                {
                    if (docList.Count == 0)
                    {
                        Console.WriteLine("List Empty");
    
                    }
                    else
                    {
                        Console.WriteLine(p.Title);
                        Console.WriteLine(p.SiteCounter);
                        Console.WriteLine(p.Press);
    
                    }
                }
                Console.ReadLine();
            }
    
    
         
        }
    
        public class Book : Document
        {
            public Book(string title, string press, int siteCounter, string author, string rok)
                : base(title, press, siteCounter)
            {
                Title = title;
                Press = press;
                SiteCounter = siteCounter;
                Rok = rok;
            }
    
            public string Rok { get; set; }
        }
    
        public class Document
        {
            public Document(string title, string press, int siteCounter)
            {
                Title = title;
                Press = press;
                SiteCounter = siteCounter;
            }
    
            public Document()
            {
                // TODO: Complete member initialization
            }
    
            public String Title { get; set; }
            public String Press { get; set; }
            public int SiteCounter { get; set; }
        }
    
        public class TitleExistException : Exception
        {
        }
    }
