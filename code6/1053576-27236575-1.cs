    private async void LoadItemCounts(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (args.Phase != 6)
        {
            throw new Exception("Not in phase 6");
        }
    
        var item = args.Item as ItemModel;
    
        var templateRoot = (Grid)args.ItemContainer.ContentTemplateRoot;
        var textBlock = (TextBlock)templateRoot.FindName("textBlock");
    
        textBlock.Text = (await DataSource.GetItemCounts(id)).ToString();
    }
