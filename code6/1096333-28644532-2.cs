    public async Task GetFolderITemsAsync()
    {
        var folderItemListResult = await search.GetFolderContent(folder));
        
        // .. use folderItemListResult
    }
