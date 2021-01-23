    public static async Task<bool> IsEmpty(StorageFolder directory)
    {
        var items = await directory.GetItemsAsync(0,1);
        return items.Count == 0;
    }
