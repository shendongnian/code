        private void LoadImageFromIsolatedStorage()
        {
            byte[] data;
 
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isfs = isf.OpenFile("image1.jpg", FileMode.Open, FileAccess.Read))
                    {
                        data = new byte[isfs.Length];
                        isfs.Read(data, 0, data.Length);
                        isfs.Close();
                    }
                }
                MemoryStream ms = new MemoryStream(data);
                BitmapImage bi = new BitmapImage();
                bi.SetSource(ms);
                imageControl1.Source = bi;
            }
            catch
            {
            }
        }
