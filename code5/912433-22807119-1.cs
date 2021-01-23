    using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (isoStore.FileExists("fileName"))
        {
            using (var fileStream = isoStore.OpenFile("fileName", FileMode.Open))
            {
                byte[] bytes = new byte[0]; // Read bytes from fileStream
                MediaLibrary library = new MediaLibrary();
                library.SavePicture("name", bytes);
            }
        }
    }
