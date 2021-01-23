    <ListBox x:Name="lb" SelectionChanged="lb_SelectionChanged"/>
    
----------
    // namespaces
    using System.Windows.Media;
    private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
    {
        var count = VisualTreeHelper.GetChildrenCount(parentElement);
        if (count == 0)
            return null;
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(parentElement, i);
            if (child != null && child is T)
            {
                return (T)child;
            }
            else
            {
                var result = FindFirstElementInVisualTree<T>(child);
                if (result != null)
                    return result;
            }
        }
        return null;
    }
    private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // get the ListBoxItem by SelectedIndex OR index number
        //ListBoxItem lbi = (ListBoxItem) this.lb.ItemContainerGenerator.ContainerFromIndex(lb.SelectedIndex);
        // get the ListBoxItem by SelectedItem or object in your ViewModel
        ListBoxItem lbi = (ListBoxItem)this.lb.ItemContainerGenerator.ContainerFromItem(lb.SelectedItem);
        // get your textbox that you want
        TextBlock tbActive= FindFirstElementInVisualTree<TextBlock>(lbi);
    }
