    public partial class AdminConsole : Window
    {
        public ObservableCollection<MyItem> Items { get; set; }
        public AdminConsole()
        {
            this.Items = new ObservableCollection<MyItem>();
            this.DataContext = this;
            InitializeComponent();
        }
        private void AddWareGroups()
        {
            DataTable MyTable = DBase.GetWareGroups();
            foreach (DataRow MyRow in MyTable.Rows)
            {
                string ItemDescription = MyRow.Field<string>(1);
                string ItemKey = MyRow.Field<string>(2);
                MyItem NewItem = new MyItem();
                NewItem.Header = ItemKey + " - " + ItemDescription;
                if (ItemKey.Length == 1)
                {
                    this.Items.Add(NewItem);
                }
                else if (ItemKey.Length == 2 || ItemKey.Length == 5 || ItemKey.Length == 6)
                {
                    IterateSubItems(1, NewItem, ItemKey, this.Items);
                }
                else // if (ItemKey.Length == 4 || ItemKey.Length == 8)
                {
                    IterateSubItems(2, NewItem, ItemKey, this.Items);
                }
            }
        }
        private void IterateSubItems(int shortenLength, MyItem newItem, string itemKey, ObservableCollection<MyItem> myCollection)
        {
            foreach (MyItem ItemChild in myCollection)
            {
                if (ItemChild.Header.Substring(0, ItemChild.Header.IndexOf(" - ")).Equals(itemKey.Substring(0, itemKey.Length - shortenLength)))
                {
                    ItemChild.SubItems.Add(newItem);
                    return;
                }
                else
                {
                    if (ItemChild.SubItems.Count > 0)
                    {
                        IterateSubItems(shortenLength, newItem, itemKey, ItemChild.SubItems);
                    }
                }
            }
        }
