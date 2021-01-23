    // Using statements
    using Microsoft.Devices;
    using Microsoft.Xna.Framework.Media;
    
    // Class Variables
    PhotoCamera cam;
    MediaLibrary library = new MediaLibrary();
    // Event hooks
    protected override void OnNavigatedTo
      (System.Windows.Navigation.NavigationEventArgs e)
    {
      if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true)
      {
        cam = new PhotoCamera(CameraType.Primary);
        cam.CaptureImageAvailable +=
          new EventHandler<Microsoft.Devices.ContentReadyEventArgs>
            (cam_CaptureImageAvailable);
        viewfinderBrush.SetSource(cam);
      }
      else
      {
        txtMessage.Text = "A Camera is not available on this device.";
      }
    }
    protected override void OnNavigatingFrom
      (System.Windows.Navigation.NavigatingCancelEventArgs e)
    {
      if (cam != null)
      {
        cam.Dispose();
      }
    }
