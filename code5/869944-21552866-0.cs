        private void MyImg()
        {
            using (MediaLibrary mediaLibrary = new MediaLibrary())
                foreach (PictureAlbum album in mediaLibrary.RootPictureAlbum.Albums)
                {
                    if (album.Name == "Camera Roll")
                    {
                        PictureCollection pictures = mediaLibrary.Pictures;
                        foreach (Picture picture in pictures)
                        {
                            // example how to use it as BitmapImage
                            BitmapImage image = new BitmapImage();
                            image.SetSource(picture.GetImage());
                            // Example how to copy to IsolatedStorage
                            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                            {
                                if (!storage.DirectoryExists("SavedImg"))
                                    storage.CreateDirectory("SavedImg");
                                if (storage.FileExists("SavedImg" + @"\" + picture.Name))
                                    storage.DeleteFile("SavedImg" + @"\" + picture.Name);
                                using (IsolatedStorageFileStream file = storage.CreateFile("SavedImg" + @"\" + picture.Name))
                                    picture.GetImage().CopyTo(file);
                            }
                        }
                    }
                }
        }
