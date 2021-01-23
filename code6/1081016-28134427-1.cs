    public partial class MainWindow : Window
    {
        private readonly List<MyItem> _items;
        public MainWindow()
        {
            InitializeComponent();
            _items = new List<MyItem>
                {
                    new MyItem{Content = "Test1",Number = "One"},
                    new MyItem{Content = "Test2",Number = "Two"},
                    new MyItem{Content = "Test3",Number = "Three"}
                };
            ComboId.ItemsSource = _items;
        }
        private void ComboID_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(ComboId.SelectedValue.ToString());
        }
    }
    public class MyItem
    {
        public string Content { get; set; }
        public string Number { get; set; }
    }
