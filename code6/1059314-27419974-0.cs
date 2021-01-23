     public MainWindow()
        {
            InitializeComponent();
            // Adding some sample data for testing.
            tiles = new ObservableCollection<Tile>();
            tiles.Add(new Tile("Item 1"));
            tiles.Add(new Tile("Item 2"));
            // below You are setting a datacontext of a MainWindow to itself
            this.DataContext = this;
        }
