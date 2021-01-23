    private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
    {
        using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
        {
            if (depthFrame != null)
            {
                depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);
            }
            else
            {
                // depthFrame is null because the request did not arrive in time
            }
        }
    }
