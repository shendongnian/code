    static async Task SavePlacesAsync(ICollection<Place> places)
    {
        var serializer = new JsonSerializer();
        var folder = ApplicationData.Current.LocalFolder;
        var file = await folder.CreateFileAsync("places.json", CreationCollisionOption.ReplaceExisting);
        using (var stream = await file.OpenStreamForWriteAsync())
        using (var writer = new StreamWriter(stream))
        {
            serializer.Serialize(writer, places);
        }
    }
