    public class MoviesViewModel : PropertyChangedBase
    {
        public ObservableCollection<Movie> Movies { get; set; }
        private ObservableCollection<Movie> _FilteredMovies;
        public ObservableCollection<Movie> FilteredMovies
        {
            get { return _FilteredMovies; }
            set 
            {
                _FilteredMovies = value;
                //Have to implement property changed because in the sort method
                //I am instantiating a new observable collection.
                OnPropertyChanged("FilteredMovies");
            }
        }
        public SortChangedCommand SortChangedCommand { get; set; }
        public MoviesViewModel()
        {
            this.Movies = new ObservableCollection<Movie>();
            #region Test Data
            this.Movies.Add(new Movie()
            {
                Name = "Movie 1"
            });
            this.Movies.Add(new Movie()
            {
                Name = "Movie 2"
            });
            this.Movies.Add(new Movie()
            {
                Name = "Movie 3"
            });
            #endregion
            //Copy the movies list to the filtered movies list (this list is displayed on the UI)
            this.FilteredMovies = new ObservableCollection<Movie>(this.Movies);
            this.SortChangedCommand = new SortChangedCommand(this);
        }
        public void Sort(string sortOption)
        {
            switch (sortOption)
            {
                case "A-Z": this.FilteredMovies = new ObservableCollection<Movie>(this.Movies.OrderBy(x => x.Name)); break;
                case "Z-A": this.FilteredMovies = new ObservableCollection<Movie>(this.Movies.OrderByDescending(x => x.Name)); break;
            }
        }
    }
