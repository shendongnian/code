    string dataToRead = string.Empty;
    using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
    {
       using (var file = storage.OpenFile("TestFile.txt", System.IO.FileMode.Open))
       {
            using (var reader = new System.IO.StreamReader(file))
            {
                    dataToRead = reader.ReadToEnd();
            }
       }
    }
