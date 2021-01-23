    private async void LoadItemCounts(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (args.Phase != 6)
        {
            throw new Exception("Not in phase 6");
        }
    
        var item = args.Item as ItemModel;
    
        var templateRoot = (Grid)args.ItemContainer.ContentTemplateRoot;
        var textBlock = (TextBlock)templateRoot.FindName("textBlock");
    
        await LoadDetails(textBlock, item.Id);
    }
    
    private async Task LoadDetails(TextBlock textBlock, string id)
    {
        int count = await DataSource.GetItemCounts(id);
    
        textBlock.Text = count.ToString();
    }
