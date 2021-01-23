    private static async Task<DeviceInformation> GetCameraID(Windows.Devices.Enumeration.Panel desired)
    {
        DeviceInformation deviceID = (await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture))
            .FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == desired);
        if (deviceID != null) return deviceID;
        else throw new Exception(string.Format("Camera of type {0} doesn't exist.", desired));
    }
    async private void InitCamera_Click(object sender, RoutedEventArgs e)
    {
        var cameraID = await GetCameraID(Windows.Devices.Enumeration.Panel.Back);
        captureManager = new MediaCapture();
        await captureManager.InitializeAsync(new MediaCaptureInitializationSettings
            {
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.Photo,
                AudioDeviceId = string.Empty,
                VideoDeviceId = cameraID.Id                    
            });
    }
