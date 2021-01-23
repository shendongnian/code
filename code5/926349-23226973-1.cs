    static async Task<ICollection<Place>> LoadPlacesAsync()
    {
        try
        {
            var serializer = new JsonSerializer();
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.GetFileAsync("places.json");
            using (var stream = await file.OpenStreamForReadAsync())
            using (var reader = new StreamReader(stream))
            using (var jReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<ICollection<Place>>(jReader, places);
            }
        }
        catch(FileNotFoundException)
        {
            return new List<Place>();
        }
    }
