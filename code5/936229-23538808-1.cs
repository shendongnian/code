    var searches = new ObservableCollection<Book>();
    searches.Add(new Book()
    {
        Desc = "The description of book 1",
        Title = "ABC Book Title"
    });
    searches.Add(new Book()
    {
        Desc = "Book Title Only",
        Title = "There's an ABC in the description of book 2"
    });
    searches.Add(new Book()
    {
        Desc = "Book Title ABC",
        Title = "ABC is in the beginning"
    });
    var ordered = new ObservableCollection<Book>(searches.OrderBy(book => book.Title).ThenBy(book => book.Desc.Contains("ABC")));
