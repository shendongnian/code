    private async void List_OnItemClick(object sender, ItemClickEventArgs e)
    {
        var item = (ItemViewModel) e.ClickedItem;
        var stream = await item.File.OpenAsync(FileAccessMode.Read);        
        Media.SetSource(stream, item.File.ContentType);
    }
