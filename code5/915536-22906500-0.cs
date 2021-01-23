        public static void SaveElementAsJPG(FrameworkElement element, string ImageName)
        {
            WriteableBitmap wBitmap = new WriteableBitmap(element, null);
            using (MemoryStream stream = new MemoryStream())
            {
                wBitmap.SaveJpeg(stream, (int)element.ActualWidth, (int)element.ActualHeight, 0, 100);
                wBitmap = null;
                //Use can either save the file to isolated storage or media library.
                //Creates file in Isolated Storage.
                using (var local = new IsolatedStorageFileStream(ImageName, FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication()))
                {
                    local.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
                }
                //Creates file in Media Library.
                var lib = new MediaLibrary();
                var picture = lib.SavePicture(ImageName, stream.GetBuffer());
            }
        }
