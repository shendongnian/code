    public partial class MainWindow : Window
    {
        private ObservableCollection<SelectableItem> Items { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            //Create dummy items, you will not need this, it's just part of the example.
            var dummyitems = Enumerable.Range(0, 100)
                                       .Select(x => new SelectableItem()
                                       {
                                           DisplayName = x.ToString()
                                       });
            DataContext = Items = new ObservableCollection<SelectableItem>(dummyitems);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Items.Count(x => x.IsSelected).ToString());
        }
    }
