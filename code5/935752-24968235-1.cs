    class ExampleDataContext
    {
        public const string DATABASE_NAME = "data.sqlite";
        private SQLiteConnection connection;
        public TableQuery<Foo> FooTable { get; private set; }
        public TableQuery<Bar> BarTable { get; private set; }
        public ExampleDataContext()
        {
            connection = new SQLiteConnection(new SQLitePlatformWinRT(), Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DATABASE_NAME));
            Initialize();
            FooTable      = connection.Table<Foo>();
            BarTable       = connection.Table<Bar>();
        }
        private void Initialize()
        {
            connection.CreateTable<Foo>();
            connection.CreateTable<Bar>();
        }
	}
