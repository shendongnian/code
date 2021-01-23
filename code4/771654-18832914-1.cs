    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MyViewModel ViewModel { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MyViewModel();
            DataContext = ViewModel;
        }
        private void ResetButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.ResetSelectedItem();
        }
    }
