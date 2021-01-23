            public class Book
            {
                public string Author { get; set; }
                public string Title { get; set; }
                public string Link { get; set; }
                public string Catgegory { get; set; }
            }
    
            public class Data
            {
                public List<Book> Books { get; set; }
    
                public Data()
                {
                    Books = new List<Book>();
                }
            }
    
                   // ....
                   var filePath = "fileName.xml";
                   var bookList = new List<Book>();
                    bookList.Add(new Book
                    {
                        Author = "H. Schildt",
                        Link = @"https://www.mcgraw-hill.co.uk/html/007174116X.html",
                        Catgegory= "Computer Programming",
                        Title = "C# 4.0 The Complete Reference",
                    });
    
                    // save
                    SerializeToXML(new Data { Books = bookList }, filePath);
                    // load
                    var data = DeserializeFromXML<Data>(filePath);
