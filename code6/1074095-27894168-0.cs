    public async static void ReadStuff(List<Items> items)
    {
        var AppStorage = ApplicationData.Current.LocalFolder;
        var itemFolders = await AppStorage.GetFolderAsync(@"App\Folder\");
        var Items = await itemFolders.GetFoldersAsync();
        foreach (var itemFolder in Items)
        {
            var itemTitle = await AppStorage.GetFileAsync(string.Format(@"App\Folder\{0}\Title.txt", itemFolder.Name));
            var itemBody = await AppStorage.GetFileAsync(string.Format(@"App\Folder\{0}\Body.txt", itemFolder.Name));
            var itemReadTitle = await FileIO.ReadTextAsync(itemTitle);
            var itemReadBody = await FileIO.ReadTextAsync(itemBody);
            x1 = itemFolder.Name;
            x2 = itemReadTitle;
            x3 = itemReadBody;
           items.Add(new Items() { ItemID = x1, ItemTitle = x2, ItemBody = x3 });
        }
    }
