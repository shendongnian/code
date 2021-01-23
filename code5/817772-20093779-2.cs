    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = this;
            SourceOfItems = new List<string>() { "Source 1", "Source 2", "Source 3" };
            Items = new ObservableCollection<string>() { "Item 1", "Item 2", "Item 3" };
        }
    
        public ObservableCollection<string> Items { get; private set; }
    
        public List<string> SourceOfItems { get; private set; }
    }
