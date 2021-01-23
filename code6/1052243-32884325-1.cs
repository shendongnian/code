    private unsafe void saveFrameTest(Object reference)
    {
      MultiSourceFrame mSF = (MultiSourceFrame)reference;
    
      using (var frame = mSF.DepthFrameReference.AcquireFrame())
      {
          if (frame != null)
          {
              using (Microsoft.Kinect.KinectBuffer depthBuffer = frame.LockImageBuffer())
              {
                  if ((frame.FrameDescription.Width * frame.FrameDescription.Height) == (depthBuffer.Size / frame.FrameDescription.BytesPerPixel))
                  {
                      ushort* frameData = (ushort*)depthBuffer.UnderlyingBuffer;
                      byte[] rawDataConverted = new byte[(int)(depthBuffer.Size / 2)];
                      long ticks = frame.RelativeTime.Subtract(startTime).Ticks;
    
                      for (int i = 0; i < (int)(depthBuffer.Size / 2); ++i)
                      {
                          ushort depth = frameData[i];
                          rawDataConverted[i] = (byte)(depth >= frame.DepthMinReliableDistance && depth <= frame.DepthMaxReliableDistance ? (depth) : 0);
                      }
    
                      String date = string.Format("{0:hh-mm-ss}", DateTime.Now);
                      String filePath = System.IO.Directory.GetCurrentDirectory() + "/test/" +date+".raw";
                      File.WriteAllBytes(filePath, rawDataConverted);
                      rawDataConverted = null;
    
                  }
              }
          }
        }
     }
