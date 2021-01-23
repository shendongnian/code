    MediaCapture mediacapture = new MediaCapture();
    await mediacapture.InitializeAsync(new MediaCaptureInitializationSettings{});
    var previewResolution = mediacapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.VideoPreview);
    var photoResolution = mediacapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.Photo);
            
            VideoEncodingProperties allResolutionsAvailable;
            uint height, width;
      //use debugger at the following line to check height & width for video preview resolution
            for (int i = 0; i < previewResolution.Count; i++)
            {
                allResolutionsAvailable = previewResolution[i] as VideoEncodingProperties;
                height = allResolutionsAvailable.Height;
                width = allResolutionsAvailable.Width;
            }
      //use debugger at the following line to check height & width for captured photo resolution
            for (int i = 0; i < photoResolution.Count; i++)
            {
                allResolutionsAvailable = photoResolution[i] as VideoEncodingProperties;
                height = allResolutionsAvailable.Height;
                width = allResolutionsAvailable.Width;
            }
