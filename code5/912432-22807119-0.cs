    using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (isoStore.FileExists("fileName"))
        {
            using (var fileStream = isoStore.OpenFile("fileName", FileMode.Open))
            {
                MediaLibrary library = new MediaLibrary();
                library.SavePicture("name", ((MemoryStream)fileStream).ToArray());
            }
        }
    }
