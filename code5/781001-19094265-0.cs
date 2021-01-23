    public delegate void TreeViewSelectedItemHandler(object sender, RoutedPropertyChangedEventArgs<object> e);
    public event TreeViewSelectedItemHandler TreeViewSelectedItemChanged;
    private void TreeViewHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        //Capture event from usercontrol and execute defined event
        if (TreeViewSelectedItemChanged != null)
        {
            TreeViewSelectedItemChanged(sender, e);
        }
    }
