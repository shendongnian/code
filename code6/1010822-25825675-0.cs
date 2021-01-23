    private MediaCapture mediaCapture = null;
    private async Task StartCapture()
    {
      string error = null;
      try
      {
        if (mediaCapture == null)
        {
          mediaCapture = new MediaCapture();
          mediaCapture.Failed += mediaCapture_Failed;
          var _deviceInformation = await GetCameraDeviceInfoAsync(Windows.Devices.Enumeration.Panel.Back);
          var settings = new MediaCaptureInitializationSettings();
          settings.StreamingCaptureMode = StreamingCaptureMode.Video;
          settings.PhotoCaptureSource = PhotoCaptureSource.VideoPreview;
          settings.AudioDeviceId = "";
          if (_deviceInformation != null)
              settings.VideoDeviceId = _deviceInformation.Id;
          await mediaCapture.InitializeAsync(settings);
          var focusSettings = new FocusSettings();
          focusSettings.AutoFocusRange = AutoFocusRange.FullRange;
          focusSettings.Mode = FocusMode.Auto;
          focusSettings.WaitForFocus = true;
          focusSettings.DisableDriverFallback = false;
          mediaCapture.VideoDeviceController.FocusControl.Configure(focusSettings);
          await mediaCapture.VideoDeviceController.ExposureControl.SetAutoAsync(true);
          mediaCapture.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
          mediaCapture.SetRecordRotation(VideoRotation.Clockwise90Degrees);
        }
        captureReceipt.Source = mediaCapture;
        await mediaCapture.StartPreviewAsync();
      }
      catch (Exception ex)
      {
        DisposeMediaCapture();
        error = ex.Message;
      }
      if (error != null)
      {
        await (new MessageBoxImpl()).ShowMessageAsync(error);
      }
    }
    private static async Task<DeviceInformation> GetCameraDeviceInfoAsync(Windows.Devices.Enumeration.Panel desiredPanel)
    {
      DeviceInformation device = (await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture))
          .FirstOrDefault(d => d.EnclosureLocation != null && d.EnclosureLocation.Panel == desiredPanel);
      if (device == null)
      {
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "No suitable devices found for the camera of type {0}.", desiredPanel));
      }
      return device;
    }
