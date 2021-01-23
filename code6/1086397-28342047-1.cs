    private bool initialized = false;
    private MediaCapture captureManager;
    async private void capturePhoto_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (initialized) return;
        try
        {
            var cameraID = await GetCameraID(Windows.Devices.Enumeration.Panel.Back);
            captureManager = new MediaCapture();
            await captureManager.InitializeAsync(new MediaCaptureInitializationSettings
            {
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview,
                AudioDeviceId = string.Empty,
                VideoDeviceId = cameraID.Id
            });
            //      StorageFile sf = await ApplicationData.Current.LocalFolder.CreateFileAsync("My Picture", CreationCollisionOption.GenerateUniqueName);
            //       ImageEncodingProperties img = new ImageEncodingProperties();
            //       img = ImageEncodingProperties.CreateJpeg();
            //        await captureManager.CapturePhotoToStorageFileAsync(img, sf);
        }
        catch (Exception ex) { (new MessageDialog("An error occured")).ShowAsync(); }
    }
    private void OffButton_Click(object sender, RoutedEventArgs e)
    {
        captureManager.Dispose();
    }
