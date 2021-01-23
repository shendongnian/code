    public async void      ContinueFileSavePicker(Windows.ApplicationModel.Activation.FileSavePickerContinu ationEventArgs args)
     {
            StorageFile file = args.File;
            if (file != null)
    {
                // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
 
                Guid encoderId = BitmapEncoder.JpegEncoderId;
 
                try
                {
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await CaptureToStreamAsync(LayoutRoot, stream, encoderId);
 
                    }
                }
                catch (Exception ex)
                {
                    DisplayMessage(ex.Message);
                }
    }
    }
