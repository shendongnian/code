        public BitmapImage ImageFoto
        {
            get
            {
                return GetImageFromIsolatedStorage(Foto);
            }
        }
        public BitmapImage GetImageFromIsolatedStorage(string imageName)
        {
            var bimg = new BitmapImage();
            using (var iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = iso.OpenFile(imageName, FileMode.Open, FileAccess.Read))
                {
                    bimg.SetSource(stream);
                }
            }
            return bimg;
        }
