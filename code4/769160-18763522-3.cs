     private WriteableBitmap ReadLocalImage(string Uri)
        {
            StreamResourceInfo sri = null;
            Uri uri = new Uri(Uri, UriKind.Relative);
            sri = Application.GetResourceStream(uri);
            BitmapImage bitmap = new BitmapImage();
            bitmap.CreateOptions = BitmapCreateOptions.None;
            bitmap.SetSource(sri.Stream);
            WriteableBitmap wb = new WriteableBitmap(bitmap);
            return wb;
        }
                      
