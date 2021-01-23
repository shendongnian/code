    public partial class MainWindow : Window
    {
        public List<Item> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new List<Item>();
            for (int i = 0; i < 10; i++)
            {
                Items.Add(new Item() {ItemName="Item " + i.ToString() });
            }
            this.DataContext = this;
        }
        private void TreeView1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as TreeView).SelectedItem != null)
            {
                Item itm = (Item)(sender as TreeView).SelectedItem;
                Console.WriteLine(itm.ItemName);
            }
        }
    }
    public class Item
    {
        public string ItemName { get; set; }
    }
