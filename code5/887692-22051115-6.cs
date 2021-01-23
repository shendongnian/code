    namespace MyMovies
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                
                Movies = new ObservableCollection<Movie>()
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
    
            public ObservableCollection<Movie> Movies { get; set; }
    
            public ICommand AddMovieCommand { get; set; }
    
            private void AddMovie()
            {
                Movies.Add(new Movie(Guid.NewGuid().ToString(), 3));
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
