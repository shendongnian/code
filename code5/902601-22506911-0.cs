     private void MainPage_Loaded(object sender, RoutedEventArgs e)
     {
    
     if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true) ||
         (PhotoCamera.IsCameraTypeSupported(CameraType.FrontFacing) == true))  {
         // Initialize the default camera.
         _photoCamera = new Microsoft.Devices.PhotoCamera();
    
         //Event is fired when the PhotoCamera object has been initialized
         _photoCamera.Initialized += new EventHandler<Microsoft.Devices.CameraOperationCompletedEventArgs>(OnPhotoCameraInitialized);
    
          //Set the VideoBrush source to the camera
          viewfinderBrush.SetSource(_photoCamera);
      }
      else {
          // The camera is not supported on the device.
          this.Dispatcher.BeginInvoke(delegate()  {
          // Write message.
              txtDebug.Text = "A Camera is not available on this device.";
          });
    
      }
    
    }
    
    private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e) {
        int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
        int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
    }
