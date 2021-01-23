    public partial class MainWindow : Window
    {
        private ObservableCollection<ItemModel> items;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public ObservableCollection<ItemModel> Items { get { return items ?? (items = new ObservableCollection<ItemModel>()); } }
    
        private void AddItem_OnClick(object sender, RoutedEventArgs e)
        {
            Items.Add(new ItemModel() { Text = Items.Count.ToString(CultureInfo.CurrentCulture) });
        }
    }
