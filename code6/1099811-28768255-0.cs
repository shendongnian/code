    private void CloseCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {           
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        // Traverse the visual tree looking for TabItem
        while ((dep != null) && !(dep is TabItem))
            dep = VisualTreeHelper.GetParent(dep);
        if (dep == null)
        {
            // Didn't find TabItem
            return;
        }
        TabItem tabitem = dep as TabItem;
        if (tabitem != null)
        {
            TabContent content = tabitem.Header as TabContent;
            if(content !=null)
                MyCollection.Remove(content);               
        }
    }
