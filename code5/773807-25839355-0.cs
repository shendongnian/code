    public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
    {
        if (args.Files.Count > 0)
        {
            var imageFile = args.Files[0] as StorageFile;
            // Ensure the stream is disposed once the image is loaded
            using (IRandomAccessStream fileStream = await imageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap
                BitmapImage bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(fileStream);
                ImageControl.Source = bitmapImage;
                await _viewModel.Upload(imageFile);
            }               
        }
    }
