     SaveImageAsByteArray()
        {
        IsolatedStorageSettings MemorySettings = IsolatedStorageSettings.ApplicationSettings;
        if (MemorySettings.Contains("ImageData"))
         MemorySettings["ImageData"] = your byte array;
        else
        MemorySettings.add("ImageData", your byte array;);
        
        IsolatedStorageSettings.ApplicationSettings.Save();
        }
        
        
        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Uri.OriginalString.Contains("img"))
            {
                
                fill();   
            }
        }
        
        private void fill()
        {
        IsolatedStorageSettings MemorySettings = IsolatedStorageSettings.ApplicationSettings;
         if (MemorySettings.Contains("ImageData"))
         byte[] bytes = MemorySettings["ImageData"] 
         MemoryStream stream = new MemoryStream(bytes);
         BitmapImage image = new BitmapImage();
         image.SetSource(stream);
           ImageBox.Source = image;
        }
