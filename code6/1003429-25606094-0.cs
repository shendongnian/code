     class StorageService : IConfigurationService
            {
                readonly StorageFolder _local = ApplicationData.Current.LocalFolder;
        
                public async void Save<T>(string key, T obj)
                {
                    var json = JsonConvert.SerializeObject(obj);
        
        
                    var dataFolder = await _local.CreateFolderAsync("DataFolder",
                CreationCollisionOption.OpenIfExists);
                    var file = await dataFolder.CreateFileAsync(key,
            CreationCollisionOption.ReplaceExisting);
                    await FileIO.WriteTextAsync(file, json);
                }
        
                public async Task<T> Load<T>(string key)
                {
                    try
                    {
                        var dataFolder = await _local.GetFolderAsync("DataFolder");
                        var file = await dataFolder.OpenStreamForReadAsync(key);
        
                        string json;
                        using (var streamReader = new StreamReader(file))
                        {
                            json = streamReader.ReadToEnd();
                        }
        
                        return JsonConvert.DeserializeObject<T>(json);
                    }
                    catch (Exception)
                    {
                        return default(T);
                    }
        
                }
        
        
            }
