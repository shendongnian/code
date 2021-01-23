    if (rootPage.EnsureUnsnapped())
      {
      FileOpenPicker openPicker = new FileOpenPicker();
      openPicker.ViewMode = PickerViewMode.Thumbnail;
      openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
      openPicker.FileTypeFilter.Add(".jpg");
      openPicker.FileTypeFilter.Add(".jpeg");
      openPicker.FileTypeFilter.Add(".png");
    
      StorageFile file = await openPicker.PickSingleFileAsync();
      if (file != null)
      {
        // Application now has read/write access to the picked file
        //OutputTextBlock.Text = "Picked photo: " + file.Name;
      }
      else
      {
        //OutputTextBlock.Text = "Operation cancelled.";
      }
    }
