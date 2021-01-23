    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool @switch = false;
        private void TreeViewDeselectAll(IEnumerable myTreeViewItems, bool value)
        {
            if (myTreeViewItems != null)
            {
                foreach (var currentItem in myTreeViewItems)
                {
                    if (currentItem is TreeViewItem)
                    {
                        TreeViewItem item = (TreeViewItem)currentItem;
                        item.IsSelected = value;
                        if (item.HasItems)
                        {
                            TreeViewDeselectAll(LogicalTreeHelper.GetChildren(item), value);
                        }
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TreeViewDeselectAll(LogicalTreeHelper.GetChildren(this.treeView), this.@switch);
        }
    }
