        //your database context
        private YourDatabaseDataContext LikeDB;
        // Define an observable collection property that controls can bind to.
        private ObservableCollection<LikeItem> _likes;
        public ObservableCollection<LikeItem> Likes
        {
            get
            {
                return _likes;
            }
            set
            {
                if (_likes != value)
                {
                    _likes = value;
                    NotifyPropertyChanged("Likes");
                }
            }
        }
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LikeDB = new YourDatabaseDataContext(YourDatabaseDataContext.DBConnectionString);
            this.DataContext = this;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Define the query to gather all of the to-do items.
            var likesFromDB = from LikeItem like in LikeDB.Likes
                                select like;
            // Execute the query and place the results into a collection.
            Likes = new ObservableCollection<LikeItem>(likesFromDB);
            // Call the base method.
            base.OnNavigatedTo(e);
        }
