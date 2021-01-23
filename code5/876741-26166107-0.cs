        public static async void WriteDataToIsolatedStorageFile(string fileName, byte[] data)
        {
            using (IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = storageFile.OpenFile(fileName, FileMode.Create))
                {
                    if ((data != null) && (data.Length > 0))
                    {
                        await stream.WriteAsync(data, 0, data.Length);
                    }
                }
            }
        }
