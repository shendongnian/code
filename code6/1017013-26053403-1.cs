    public static class TreeViewScrollBehavior
    {
        public static DependencyProperty ScrollItemToCenterProperty =
    DependencyProperty.RegisterAttached("ScrollItemToCenter", typeof(bool),
    typeof(TreeViewScrollBehavior), new UIPropertyMetadata(false, OnScrollItemToCenter));
        public static bool GetScrollItemToCenter(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollItemToCenterProperty);
        }
        public static void SetScrollItemToCenter(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollItemToCenterProperty, value);
        }
        public static void OnScrollItemToCenter(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            
            if ((bool)e.NewValue)
            {
                //TreeViewItem t = GetTreeViewItem(d);
                TreeViewItem t = (TreeViewItem)d;
                TryScrollToCenterOfView(GetTree(t), t);
            }
        }
