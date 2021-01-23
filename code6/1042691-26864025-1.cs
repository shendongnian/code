    class Book : IBook
    {
        public String Author { get; set; }
        public String Title { get; set; }
        private int Quantity {get;set;}
        public Book(String aut, String pav, int qua)
        {
            this.Author = aut;
            this.Title = pav;
            this.Quantity = qua;
        }
    }
    class BookWithType
    {
        public IBook Book { get; set; }
        public String Type { get; set; }
        public BookWithType(IBook book, String type)
        {
            this.Book = book;
            this.Type = type;
        }
    }
