    var store = IsolatedStorageFile.GetUserStoreForApplication();
    try
    {
        if (store.FileExists(path))
        {
            using (var stream = store.OpenFile("fileName", FileMode.Open))
            {
                //Read your file
            }
        }
    }
    catch (Exception e)
    {
        //Handle Exception
    }
