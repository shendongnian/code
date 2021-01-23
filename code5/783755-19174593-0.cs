    public void StopKinect()
    {
       if (this.sensor == null)
       {
           return;
       }
   
       if (this.sensor.SkeletonStream.IsEnabled)
       {
          this.sensor.SkeletonStream.Disable();
       }
       if (this.sensor.ColorStream.IsEnabled)
       {
          this.sensor.ColorStream.Disable();
       }
       if (this.sensor.DepthStream.IsEnabled)
       {
          this.sensor.DepthStream.Disable();
       }
       // detach event handlers
       this.sensor.SkeletonFrameReady -= this.SensorSkeletonFrameReady;
 
       try
       {
          this.sensor.Stop()
       }
       catch (Exception e)
       {
           Debug.WriteLine("unknown Exception {0}", e.Message)
       }
    }
