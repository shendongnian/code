    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Movie> _movies;
        /// <summary>
        /// Collection of movies.
        /// </summary>
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    RaisePropertyChanged("Movies");
                }
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public MyViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            Movies.Add(new Movie() { Title = "Gravity", Info = "Gravity is about..." });
            Movies.Add(new Movie() { Title = "Avatar", Info = "Avatar is about..." });
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
