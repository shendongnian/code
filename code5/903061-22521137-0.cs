     class Docs
    {
        public static int cursorLimit { get; set; }
        //Create a new Observable collection.
        //This should be moved to a seperate class according ot MVVM standards.
        private static ObservableCollection<Tweets> _TweetOC = new ObservableCollection<Tweets>();
        public static ObservableCollection<Tweets> TweetOC
        {
            get { return _TweetOC; }
            set
            {
                _TweetOC = value;
            }
        }
        private static ObservableCollection<Tweets> _GeoOC = new ObservableCollection<Tweets>();
        public static ObservableCollection<Tweets> GeoOC
        {
            get { return _GeoOC; }
            set
            {
                _GeoOC = value;
            }
        }
