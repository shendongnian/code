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
    newCapture  = new MediaCapture();
    await newCapture.InitializeAsync(new MediaCaptureInitializationSettings
        {
            // Choose the webcam you want
            VideoDeviceId = backWebcam.Id,
            AudioDeviceId = "",
            StreamingCaptureMode = StreamingCaptureMode.Video,
            PhotoCaptureSource = PhotoCaptureSource.VideoPreview
        });
    // Set the source of the CaptureElement to your MediaCapture
    // (In my XAML I called the CaptureElement *Capture*)
    Capture.Source = newCapture;
    // Start the preview
    await newCapture.StartPreviewAsync();
