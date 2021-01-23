    private void ImageOpened(object sender, RoutedEventArgs e)
    {
        WriteableBitmap wb = new WriteableBitmap((BitmapImage)sender);
            using (IsolatedStorageFile newIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                String tempJPEG = randomNumber.ToString();
                IsolatedStorageFileStream fileStream = newIsolatedStorage.CreateFile(tempJPEG);
                //fileStream.Close();
                //fileStream.Flush();
                BitmapImage image = new BitmapImage(new Uri("" + uri ));
                image.CreateOptions = BitmapCreateOptions.None;
                System.Windows.Media.Imaging.Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
              }
    }
