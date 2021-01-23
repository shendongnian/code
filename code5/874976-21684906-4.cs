    public partial class MainWindow : Window
    {
        public MyViewModel ViewModel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MyViewModel();
            DataContext = ViewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = ViewModel.Movies.FirstOrDefault();
            if (movie != null)
            {
                movie.Info = "This is the new information";
            } 
        }
    }
