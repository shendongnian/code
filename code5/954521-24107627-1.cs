    //Domain Object
    public class Book
    {
        public int BookId { get; set; }
        public bool Favourite { get; set; }
    }
    //View Model
    public class BookVm : ImplementsPropertyChanged
    {
        private readonly Book book;
        //Store the book
        public BookVm(Book book)
        {
            this.book = book;
        }
        private bool favorite;
        public int BookId
        {
            get { return book.BookId; }
        }
        public bool Favorite
        {
            get { return favorite; }
            set
            {
                if (favorite != value)
                {
                    favorite = value;
                    //Update the database 
                    UpdateDatabase();
                }
            }
        }
        private void UpdateDatabase()
        {
            //set the favorite value of the domain book
            book.Favourite = favorite;
            DataService.UpdateBook(book);
        }
    }
