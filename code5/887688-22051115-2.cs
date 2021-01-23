    namespace MyMovies
    {
        public partial class MainWindow : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private ObservableCollection<Movie> _movies = new ObservableCollection<Movie>(); 
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                
                _movies = new ObservableCollection<Movie>()
                    {
                        new Movie("Lock, Stock and Two Smoking Barrels", 4),
                        new Movie("Life of Brian", 5),
                    };
    
                var addMovieCommand = new RoutedUICommand();
                CommandManager.RegisterClassCommandBinding(typeof(Window),
                    new CommandBinding(
                        addMovieCommand,
                        (sender, args) => AddMovie(),
                        (sender, args) => args.CanExecute = true));
                AddMovieCommand = addMovieCommand;
            }
    
            public ObservableCollection<Movie> Movies
            {
                get { return _movies; }
                set { _movies = value; OnPropertyChanged(); }
            }
    
            public ICommand AddMovieCommand { get; set; }
    
            private void AddMovie()
            {
                _movies.Add(new Movie(Guid.NewGuid().ToString(), 3));
                OnPropertyChanged();
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class Movie
        {
            public Movie(string name, int stars)
            {
                Name = name;
                Stars = stars;
            }
    
            public string Name { get; set; }
            public int Stars { get; set; }
        }
    }
