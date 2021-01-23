    public static class IsolatedStorageOperations
        {
            public static async Task Save<T>(this T obj, string file)
            {
                await Task.Run(() =>
                {
                    IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                    IsolatedStorageFileStream stream = null;
    
                    try
                    {
                        stream = storage.CreateFile(file);
                        var serializer = new SharpSerializer();
                        serializer.Serialize(obj,stream);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                });
            }
    
            public static async Task<T> Load<T>(string file)
            {
    
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                T obj = Activator.CreateInstance<T>();
    
                if (storage.FileExists(file))
                {
                    IsolatedStorageFileStream stream = null;
                    try
                    {
                        stream = storage.OpenFile(file, FileMode.Open);
                        var serializer = new SharpSerializer();
    
                        obj = (T)serializer.Deserialize(stream);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                            stream.Dispose();
                        }
                    }
                    return obj;
                }
                await obj.Save(file);
                return obj;
            }
        }
