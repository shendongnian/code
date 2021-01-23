      MediaLibrary m = new MediaLibrary();
        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (store.DirectoryExists("ImagesZipFolder"))
            {
              
                store.DeleteDirectory("ImagesZipFolder");
            }
            if (!store.DirectoryExists("ImagesZipFolder"))
            {
                store.CreateDirectory("ImagesZipFolder");
                foreach (var picture in m.Pictures)
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(@"ImagesZipFolder/" + picture.Name, FileMode.CreateNew, store))
                    {
                        BitmapImage image = new BitmapImage();
                        image.SetSource(picture.GetImage());
                        byte[] bytes = ConvertToBytes(image);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
