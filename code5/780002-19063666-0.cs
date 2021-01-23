            public void setBackgroundImage(String pictureName)
           {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = storage.OpenFile(pictureName, FileMode.Open))
                {
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.SetSource(stream);
                    BackgroundImg.ImageSource = bitmapimage;
                   
                }
            }
        }
