    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Dictionary<string, object> itemsSource = new Dictionary<string, object>();
            itemsSource.Add(Convert.ToString(TextAlignment.Center), TextAlignment.Center);
            itemsSource.Add(Convert.ToString(TextAlignment.Justify), TextAlignment.Justify);
            itemsSource.Add(Convert.ToString(TextAlignment.Left), TextAlignment.Left);
            itemsSource.Add(Convert.ToString(TextAlignment.Right), TextAlignment.Right);
    
            MultiSelectComboBox.ItemsSource = itemsSource;
        }
    }
