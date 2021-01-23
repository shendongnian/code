    public class MyItem
    {
        public string Name { get; set; }
        public string SubName { get; set; }
        public MyItem(string name, string subName)
        {
            Name = name;
            SubName = subName;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var comboBoxItems = new List<MyItem>();
            comboBoxItems.Add(new MyItem("All", null));
            comboBoxItems.Add(new MyItem("Item 1", null));
            comboBoxItems.Add(new MyItem("Item 2", null));
            MyCombo.ItemsSource = comboBoxItems;
            var listViewItems = new List<MyItem>();
            listViewItems.Add(new MyItem("Item 1", "SubItem 1.1"));
            listViewItems.Add(new MyItem("Item 1", "SubItem 1.2"));
            listViewItems.Add(new MyItem("Item 1", "SubItem 1.3"));
            listViewItems.Add(new MyItem("Item 2", "SubItem 2.1"));
            listViewItems.Add(new MyItem("Item 2", "SubItem 2.2"));
            listViewItems.Add(new MyItem("Item 2", "SubItem 2.3"));
            listViewItems.Add(new MyItem("Item 2", "SubItem 2.4"));
            CollectionView view = (CollectionView) CollectionViewSource.GetDefaultView(listViewItems);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Name");
            view.GroupDescriptions.Add(groupDescription);
            view.Filter = itemObject =>
                {
                    MyItem item = (MyItem) itemObject;
                    string comboName = (string) MyCombo.SelectedValue;
                    return item.Name == comboName || comboName == "All";
                };
            MyCombo.SelectionChanged += (s, e) => view.Refresh();
            MyList.ItemsSource = view;
        }
    }
