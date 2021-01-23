    // First need to find all webcams
    DeviceInformationCollection webcamList = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture)
    
    // Then I do a query to find the front webcam
    DeviceInformation frontWebcam = (from webcam in webcamList
     where webcam.EnclosureLocation != null 
     && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front
     select webcam).FirstOrDefault();
    
    // Same for the back webcam
    DeviceInformation backWebcam = (from webcam in webcamList
     where webcam.EnclosureLocation != null 
     && webcam.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back
     select webcam).FirstOrDefault();
    
    // Then you need to initialize your MediaCapture
    var captureManager = new MediaCapture();
    await captureManager.InitializeAsync(new MediaCaptureInitializationSettings
    {
        // Choose the webcam you want (backWebcam or frontWebcam)
        VideoDeviceId = backWebcam.Id,
        AudioDeviceId = "",
        StreamingCaptureMode = StreamingCaptureMode.Video,
        PhotoCaptureSource = PhotoCaptureSource.VideoPreview
    });
    
    // Set the source of the CaptureElement to your MediaCapture
    capturePreview1.Source = captureManager;
    
    // Start the preview
    await captureManager.StartPreviewAsync();
