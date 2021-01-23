     private async void Download()
        {
            Windows.UI.Xaml.Media.Imaging.BitmapImage image = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            image.ImageFailed += image_ImageFailed;
            image.ImageOpened += image_ImageOpened;
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Logo.scale-100.png", UriKind.Absolute));
            var stream = await file.OpenStreamForReadAsync();
            await image.SetSourceAsync(stream.AsRandomAccessStream());
        }
        void image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageDialog dg = new MessageDialog("Image Failed");
            dg.ShowAsync();
        }
        void image_ImageOpened(object sender, RoutedEventArgs e)
        {
            MessageDialog dg = new MessageDialog("Image Opened");
            dg.ShowAsync();
        }
