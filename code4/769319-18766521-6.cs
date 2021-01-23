    private DepthImageFrame _depthImageFrame;
    private bool _imageUsing;
    private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
     using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
     {
      if (depthFrame != null)
      {
          if (!_imageUsing)
              _depthImageFrame = depthFrame;
          
          //your code
      }
     }
    }
