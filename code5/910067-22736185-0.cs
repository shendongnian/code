     try
     {
       sensor.DepthStream.Range = DepthRange.Near;
       sensor.SkeletonStream.EnableTrackingInNearRange = true;
     }
     catch (InvalidOperationException)
     {
       // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
       sensor.DepthStream.Range = DepthRange.Default;
       sensor.SkeletonStream.EnableTrackingInNearRange = false;
     }
