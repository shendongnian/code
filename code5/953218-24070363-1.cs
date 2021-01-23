    private List<string> ReadHistory()
        {
            List<string> history = new List<string>();
            using (IsolatedStorageFile storeFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storeFile.FileExists("Browse_History.txt"))
                {
                    using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream("Browse_History.txt", System.IO.FileMode.Open, FileAccess.Read, storeFile)))
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
