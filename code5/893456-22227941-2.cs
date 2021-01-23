    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var items = new List<MyListViewItemData>();
            items.Add(new MyListViewItemData()
                {
                    ComboDefaultValue = 1,
                    ComboItems = new List<Tuple<int, string>>(){ new Tuple<int, string>(1, "m/s"), new Tuple<int, string>(2, "km/h") }
                });
            items.Add(new MyListViewItemData()
                {
                    ComboDefaultValue = 10,
                    ComboItems = new List<Tuple<int, string>>() { new Tuple<int, string>(10, "seconds"), new Tuple<int, string>(20, "minutes") }
                });
            LV_Items.ItemsSource = items;
        }
    }
    public class MyListViewItemData
    {
        public List<Tuple<int, String>> ComboItems { get; set; }
        public int ComboDefaultValue { get; set; }
    }
