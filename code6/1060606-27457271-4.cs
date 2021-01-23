    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            Random rnd = new Random(DateTime.Now.Millisecond);
            HashSet<int> ids = new HashSet<int>();
            for (int i = 0; i < 7; i++)
            {
                int id = 0;
                do
                {
                    id = rnd.Next(0, 10);
                } while (ids.Contains(id));
                ids.Add(id);
                items.Add(new ListViewItem() { Id = id, Name = "Item-" + i });
            }
            int? selectedId = listView1.SelectedItem != null ? (listView1.SelectedItem as ListViewItem).Id : (int?)null;
            listView1.ItemsSource = items;
    
            if (selectedId.HasValue)
            {
                listView1.SelectedItem = items.Where(x => x.Id == selectedId).FirstOrDefault();
                listView1.Focus();
            }
        }
    }
    
    class ListViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
