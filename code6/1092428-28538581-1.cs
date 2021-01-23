     public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new GameStateViewModel();
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (viewModel.CurrentScore <= 0)
                {
                    this.NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
                }
            };
            this.DataContext = viewModel;
        }
    }
