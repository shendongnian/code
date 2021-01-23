    [Localizable(false)]
    public class ItemsControlResizingBehavior : Behavior<ItemsControl>
    {
        public static readonly DependencyProperty VisibleItemsCountProperty =
            DependencyProperty.Register("VisibleItemsCount",
                typeof(int),
                typeof(ItemsControlResizingBehavior),
                new FrameworkPropertyMetadata(0, OnSizeChanged));
        
        public int VisibleItemsCount
        {
            get { return (int)GetValue(VisibleItemsCountProperty); }
            set { SetValue(VisibleItemsCountProperty, value); }
        }
        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;
            var behavior = (ItemsControlResizingBehavior)d;
            if (behavior.AssociatedObject == null)
                return;
            behavior.ComputeVisibleItemsCount(behavior.AssociatedObject);
        }
        private SizeChangedEventHandler _listViewSizeChangedEventHandler;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            var itemsControl = (ItemsControl)sender;
            _listViewSizeChangedEventHandler = (x, y) => ComputeVisibleItemsCount(itemsControl);
            var treeListView = AssociatedObject as TreeListView;
            if (treeListView != null)
                treeListView.SizeChanged += _listViewSizeChangedEventHandler;
            var listView = AssociatedObject as ListView;
            if (listView != null)
                listView.SizeChanged += _listViewSizeChangedEventHandler;
            itemsControl.Loaded -= AssociatedObject_Loaded;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            var treeListView = AssociatedObject as TreeListView;
            if (treeListView != null)
                treeListView.SizeChanged -= _listViewSizeChangedEventHandler;
            var listView = AssociatedObject as ListView;
            if (listView != null)
                listView.SizeChanged -= _listViewSizeChangedEventHandler;
        }
        private void ComputeVisibleItemsCount(ItemsControl itemsControl)
        {
            if (itemsControl.Items.Count <= 0)
                return;
            if (itemsControl is TreeListView)
            {
                VisibleItemsCount = GetTreeViewItems(itemsControl).Count(x => x.IsVisibleInUI(itemsControl));
            }
            if (itemsControl is ListView)
            {
                VisibleItemsCount = GetListViewItems(itemsControl).Count(x => x.IsVisibleInUI(itemsControl));
            }
        }
        
        private static IEnumerable<TreeViewItem> GetTreeViewItems(ItemsControl tree)
        {
            for (int i = 0; i < tree.Items.Count; i++)
            {
                var item = (TreeViewItem)tree.ItemContainerGenerator.ContainerFromIndex(i);
                if (item == null)
                    continue;
                yield return item;
                foreach (TreeViewItem subItem in GetTreeViewItems(item))
                {
                    yield return subItem;
                }
            }
        }
        private static IEnumerable<ListViewItem> GetListViewItems(ItemsControl list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                var item = (ListViewItem)list.ItemContainerGenerator.ContainerFromIndex(i);
                if (item == null)
                    continue;
                yield return item;
            }
        }
    }
