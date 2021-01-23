    public partial class ListViewSearch : Window
    {
        private ViewModel ViewModel;
        public ListViewSearch()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();
        }
        private void FindAll_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Filter();
        }
    }
