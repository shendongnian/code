    private void MyListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (this.MyListView.SelectedItems.Contains(args.Item))
        {
            // get the container
            var container = (ListViewItem)args.ItemContainer; 
    
            // do your visual state change here, when the container was previously null
        }
    }
