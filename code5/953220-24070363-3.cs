    private List<string> LoadFavoirties()
        {
            List<string> history = new List<string>();
            using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (appStorage.FileExists("Browser_Favorties.txt"))
                {
                    using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream("Browser_Favorties.txt", System.IO.FileMode.Open, FileAccess.Read, appStorage)))
                    {
                        var uri = reader.ReadLine();
                        while (!string.IsNullOrEmpty(uri))
                        {
                            history.Add(uri);
                            uri = reader.ReadLine();
                        }
                        reader.Close();
                        return history;
                    }
                }
            }
            return null;
        }
