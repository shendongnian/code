    public class Book
    {
        public String Author { get; set; }
        public String Title { get; set; }
        public int Pages {get;set;}
        public string Type {get;set;}
        public Book(String aut, String pav, int pages, string type)
        {
            this.Author = aut;
            this.Title = pav;
            this.Pages = pages;
            this.Type = type;
        }
    }
