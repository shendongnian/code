    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            Items = BuildItems();
            InitializeComponent();
        }
        private List<Item> BuildItems()
        {
            var list = new List<Item>();
            //  Add option "A" with suboptions
            list.Add(new Item("A", Brushes.Red, Brushes.Yellow, new List<Item>
                {
                    new Item("E", Brushes.Green, Brushes.Black),
                    new Item("F", Brushes.LightBlue, Brushes.Black),
                    new Item("G", Brushes.Red, Brushes.Black),
                    new Item("H", Brushes.LemonChiffon, Brushes.Black)
                }));
            // Add option "B"
            list.Add(new Item("B", Brushes.Yellow, Brushes.Green));
            // Add option "C"
            list.Add(new Item("C", Brushes.Blue, Brushes.Yellow));
            // Add option "D"
            list.Add(new Item("D", Brushes.GreenYellow, Brushes.Yellow));
            return list;
        }
        private List<Item> item;
        public List<Item> Items
        {
            get { return item; }
            set
            {
                if (item != value)
                {
                    item = value;
                    OnPropertyChanged("Items");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).Tag as Item;
            if (item != null && item.Items != null)
                Items = item.Items;
        }
    }
