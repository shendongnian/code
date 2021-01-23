    public class MainWindow: Window
    {
        public MainViewModel ViewModel { get { return DataContext as MainViewModel; } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        public void Registrar_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Registrar();
        }
        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clear();
        }
    }
