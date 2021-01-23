    private void ListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (VisualTreeHelper.GetParent(e.OriginalSource as UIElement) is ListBoxItem)
        {
            ListBoxItem item = (ListBoxItem)VisualTreeHelper.GetParent(e.OriginalSource as UIElement);
            if (item == null) return;
            if (item.IsSelected)
            {
                e.Handled = true;
            }
        }     
    }
