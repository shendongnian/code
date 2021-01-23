    private DepthImageFrame _depthImageFrame;
    private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
     using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
     {
      if (depthFrame != null)
      {
          _depthImageFrame = depthFrame;
          //your code
      }
     }
    }
