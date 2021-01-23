    namespace ConsoleApplication1
    {
        internal class Program
        {
    
            private static void Main(string[] args)
            {
                Document w = new Book(Title, Press, SiteCounter, Author, null);
    
                w.Title = "The title of the document";
                w.Press = "The press of the document";
                w.SiteCounter = 10;
                
                DocumentList docList = new DocumentList();
    
                try
                {
                    docList.AddDocument(w);
                }
                catch (TitleExistException e)
                {
                    Console.WriteLine(e);
    
                }
    
                DisplayListOfDocuments(docList);
            }
    
            public static void DisplayListOfDocuments(DocumentList docList)
            {
                Console.WriteLine("List");
                
                // for the record calledList is unnecessary but I'll let you figure out why.
                List<Document> calledList = docList.Documents;
    
                Console.WriteLine(calledList.Count);
                foreach (Document p in calledList)
                {
                    if (calledList.Count == 0)
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
    
    
            public static string Author { get; set; }
    
            public static int SiteCounter { get; set; }
    
            public static string Press { get; set; }
    
            public static string Title { get; set; }
        }
    
        public class Book : Document
        {
            public Book(string title, string press, int siteCounter, string author, string rok)
                : base(title, press, siteCounter)
            {
    
            }
        }
    
        public class Document
        {
            public Document(string Title, string Press, int SiteCounter)
            {
                this.Title = Title;
                this.Press = Press;
                this.SiteCounter = SiteCounter;
            }
    
            public Document()
            {
                // TODO: Complete member initialization
            }
    
            public String Title { get; set; }
    
            public String Press { get; set; }
    
    
            public int SiteCounter { get; set; }
    
            public override string ToString()
            {
                return base.ToString();
            }
    
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
    
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    
        public class DocumentList
        {
            private List<Document> documents = new List<Document>();
    
            public List<Document> Documents
            {
                get { return documents; }
    
            }
    
            public DocumentList()
            {
    
            }
    
            public void AddDocument(Document document)
            {
                if (documents.Contains(document))
                {
                    throw new TitleExistException("Dodanie dokumentu o tytule ktory juz istnieje");
                }
    
                documents.Add(document);
            }
    
        }
    
        public class TitleExistException : Exception
        {
            public TitleExistException(string dodanieDokumentuOTytuleKtoryJuzIstnieje)
            {
                throw new NotImplementedException();
            }
        }
    }
