    public partial class MainWindow : Window
    {
        FilterableObservableCollection items;
    
        public MainWindow()
        {
    
            items = new FilterableObservableCollection()
            {
                new ListViewItem() { Name = "Hallo", IsArchived = false },
                new ListViewItem() { Name = "world", IsArchived = true },
                new ListViewItem() { Name = "!!!", IsArchived = false }
            };
    
            InitializeComponent();
        }
    
        public FilterableObservableCollection MyItems
        {
            get { return items; }
        }
    
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            items.NotArchivedOnlyFilterEnabled = (sender as CheckBox).IsChecked.Value;
        }
    
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            items.NotArchivedOnlyFilterEnabled = (sender as CheckBox).IsChecked.Value;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items.Add(new ListViewItem() { Name = "Item" + (items.Count + 1), IsArchived = items.Count % 2 == 0 });
        }
    }
    
