    await Task.WhenAll(itemLinks.Select(DownloadAsync));
    private static async Task DownloadAsync(string itemLink)
    {
        string[] sourceParts = itemLinks[l].Split('/');
        string fileName = sourceParts[sourceParts.Count() - 1];
        using (var client = new HttpClient())
        using (var source = await client.GetStreamAsync(itemLink))
        using (IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream stream = storageFile.OpenFile(FILE_NAME, FileMode.Create))
        {
            await source.CopyToAsync(stream);
        }
        ... // Use fileName
    }
