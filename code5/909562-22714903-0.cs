    FileOpenPicker openPicker = new FileOpenPicker();
    openPicker.ViewMode = PickerViewMode.Thumbnail;
    openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    openPicker.FileTypeFilter.Add(".jpg");
    openPicker.FileTypeFilter.Add(".jpeg");
    openPicker.FileTypeFilter.Add(".png");
    
    StorageFile file = await openPicker.PickSingleFileAsync();
    if (file != null)
       {
          using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
          {
               // Set the image source to the selected bitmap 
               BitmapImage bitmapImage = new BitmapImage();
               await bitmapImage.SetSourceAsync(fileStream);
               big_image.Source = bitmapImage;
          }
       }
