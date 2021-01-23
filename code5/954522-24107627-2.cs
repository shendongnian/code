    public class BookController
    {
        public void Display()
        {
            IEnumerable<Book> books = DataService.FetchBooks();
            ObservableCollection<BookVm> bookVms = new ObservableCollection<BookVm>();
            foreach (var book in books)
            {
                BookVm bookVm = new BookVm(book);
                bookVms.Add(bookVm);
            }
            //Get the View and then bind using the bookVms collection
        }
    }
