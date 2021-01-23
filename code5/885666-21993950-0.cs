    private void ListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        // you can check which mouse button, its state, or use the correct event.
        // get the element the mouse is currently over
        var uie = ListBox.InputHitTest(Mouse.GetPosition(this.ListBox));
    
        if (uie == null)
            return;
        // navigate to its ListBoxItem container
        var listBoxItem = FindParent<ListBoxItem>((FrameworkElement) uie);
    
        // in case the click was not over a listBoxItem
        if (listBoxItem == null)
             return;
        // here is the index
        int index = this.ListBox.ItemContainerGenerator.IndexFromContainer(listBoxItem);
        MessageBox.Show(index.ToString());
    }
    public static T FindParent<T>(FrameworkElement child) where T : DependencyObject
    {
        T parent = null;
        var currentParent = VisualTreeHelper.GetParent(child);
        while (currentParent != null)
        {
           // check the current parent
           if (currentParent is T)
           {
              parent = (T)currentParent;
              break;
           }
           // find the next parent
           currentParent = VisualTreeHelper.GetParent(currentParent);
        }
        return parent;
    }
