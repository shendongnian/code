    using System.IO;
    using System.IO.IsolatedStorage;
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var stream = store.OpenFile("testImage.jpg", FileMode.Open))
        {
            using (var reader = new ExifReader(stream))
            {
                // ...
            }
        }
    }
