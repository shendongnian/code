    public class Book
    {
        public string Name { get; set; }
        public IList<string> Authors { get; set; }
    }
    //....
    AutoMapper.Mapper.CreateMap<Book, Book>();
            
    var book1 = new Book
    {
        Name = "Original Book",
        Authors = new List<string>()
        {
            "Joe Blogs",
            "Jane Blogs"
        }
    };
    var bookCopy = AutoMapper.Mapper.Map<Book>(book1);
    book1.Authors.Add("Me");
    //book has 3 authors and bookCopy has the original 2
