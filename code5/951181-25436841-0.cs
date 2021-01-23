    private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DependencyObject obj = (DependencyObject)sender;
            obj = loopUntilDesiredTypeIsFound<ListBoxItem>(obj);
            for (int i=0; i<VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                ListBoxItem item = (ListBoxItem)VisualTreeHelper.GetChild(obj,i);
                if (item.IsSelected)
                {
                    DependencyObject container = loopUntilDesiredTypeIsFound<Grid>(item);
    //here we will have the Grid container for the display objects, such as textblocks, checkboxes, etc..
                    break;
                }
            }
        }
        private DependencyObject getChild(DependencyObject obj)
        {
            if (VisualTreeHelper.GetChildrenCount(obj) > 0 )
            {
                return VisualTreeHelper.GetChild(obj, 0);
            }
            return null;
        }
        private DependencyObject loopUntilDesiredTypeIsFound<T>(DependencyObject obj)
        {
            while (obj != null)
            {
                int children = VisualTreeHelper.GetChildrenCount(obj);
                if (getChild(obj) is T)
                {
                    return obj;
                }
                obj = getChild(obj);
            }
            return null;
        }
