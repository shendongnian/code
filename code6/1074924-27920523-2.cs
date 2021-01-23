    public class MovieViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<Movie> _FilteredMovies;
        public ObservableCollection<Movie> FilteredMovies
        {
            get { return _FilteredMovies; }
            set 
            {
                _FilteredMovies = value;
                //Need to implement INotifyPropertyChanged here because 
                //I am instantiating a new observable collection in the enabled changed
                //method. This will refresh the binding on the DataGrid.
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Filter> Filters { get; set; }
        public MovieViewModel()
        {
            this.Movies = new ObservableCollection<Movie>();
            this.Filters = new ObservableCollection<Filter>();
            #region Sample Data
            this.Movies.Add(new Movie()
                {
                    Name = "Movie Action",
                    Genre = "Action"
                });
            this.Movies.Add(new Movie()
            {
                Name = "Movie Romance",
                Genre = "Romance"
            });
            this.Movies.Add(new Movie()
            {
                Name = "Movie Comedy",
                Genre = "Comedy"
            });
            this.Filters.Add(new Filter("Action"));
            this.Filters.Add(new Filter("Romance"));
            this.Filters.Add(new Filter("Comedy"));
            foreach (Filter filter in this.Filters)
                filter.OnEnabledChanged += filter_OnEnabledChanged;
            #endregion
        }
        void filter_OnEnabledChanged(object sender, EventArgs e)
        {
            var filteredMovies = (from m in this.Movies
                                    join f in this.Filters on m.Genre equals f.Genre
                                    where f.IsEnabled
                                    select m).ToList();
            this.FilteredMovies = new ObservableCollection<Movie>(filteredMovies);
        }
    }
