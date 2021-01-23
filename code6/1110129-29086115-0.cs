    public partial class MainWindow : Window
    {
    
        private UIControls viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new UIControls();
            this.DataContext = viewModel;
        }
    
        private void Name_Click(object sender, RoutedEventArgs e)
        {
            viewModel.FirstName = "Mike";
            viewModel.LastName = "Smith";
        }
