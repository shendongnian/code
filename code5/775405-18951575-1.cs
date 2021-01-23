    public partial class ListBoxInCell : Window
    {
        public ViewModel ViewModel { get; set; }
        public ListBoxInCell()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();
        }
        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ViewModel.SelectedItem.SelectedDetail);
        }
    }
