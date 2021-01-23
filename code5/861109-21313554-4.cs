    private readonly List<Book> books;
    public MainViewModel( )
    {
        this.books = new List<Book>
        {
            new Book
            {
                Name = "Book 1",
                Type = BookType.Fantasy
            },
            new Book
            {
                Name = "Book 2",
                Type = BookType.Fantasy
            },
            new Book
            {
                Name = "Book 3",
                Type = BookType.Fantasy
            },
            new Book
            {
                Name = "Book 4",
                Type = BookType.SciFi
            }
        };
    }
    public ICollectionView Books
    {
        get
        {
            var source = CollectionViewSource.GetDefaultView( this.books );
            source.GroupDescriptions.Add( new PropertyGroupDescription( "Type" ) 
        );
        return source;
    }
    
