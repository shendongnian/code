    public partial class MainWindow : Window
    {
        ExpanderListViewModel vm = new ExpanderListViewModel();
        public MainWindow()
        {
            InitializeComponent();
            StackPanel1.DataContext = vm;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.SelectedExpander = "2";
        }
    }
