    public void ImageWIthLoader(string url, int width, int height)
     {
          Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
         m_image = new Image();
         m_loader_bitmap = new BitmapImage(new Uri("Assets/Images/image_await_background.png", UriKind.Relative));
         m_loader_bitmap.DecodePixelWidth = width;
         m_loader_bitmap.DecodePixelHeight = height;
         m_image.Source = m_loader_bitmap;
         m_loader_bitmap = null;
         
         m_source_bitmap = new BitmapImage(new Uri(url));
         m_source_bitmap.CreateOptions = BitmapCreateOptions.None;
         m_source_bitmap.ImageOpened += bitmapLoaded;
            });
     }
