    public async Task<bool> SaveSubscriptions(List<Show> subs)
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
        
                try
                {
                    string data = JsonConvert.SerializeObject(subs, Formatting.Indented);
                    Byte[] bytes = Encoding.UTF8.GetBytes(data);
        
                    using (IsolatedStorageFileStream stream = storage.CreateFile("Subscriptions\\subscriptions.json"))
                    {
                        stream.Seek(0, SeekOrigin.End);
                        await stream.WriteAsync(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
                return true;
            }
