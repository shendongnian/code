    public class BookCollection : ObservableCollection<Book> // Notice the Inheritance to ObservableCollection
    {
        public void SetCriteria(string search)
        {
            if(string.IsNullOrEmpty(search))
                return;
            
            foreach (var book in this)
            {
                if(book.Title.Contains(search))
                    book.TitleRank = book.Title.IndexOf(search, StringComparison.InvariantCulture);
                
                if(book.Desc.Contains(search))
                    book.DescRank = book.Desc.IndexOf(search, StringComparison.InvariantCulture);
            }
            var collection = new List<Book>(base.Items.OrderBy(book => book.Title)
                                                      .ThenBy(book => book.Desc)
                                                      .ThenBy(book => book.TitleRank)
                                                      .ThenBy(book => book.DescRank));
            Items.Clear();
            collection.ForEach(Add);
            collection.Clear();
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int TitleRank { get; internal set; }
        public int DescRank { get; internal set; }
    }
