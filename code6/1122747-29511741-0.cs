    for (int i = 0; i < 100; i++)
    {
       try
       {
    
           Bitmap videoFrame = reader.ReadVideoFrame();
           int w = videoFrame.Width;
           int h = videoFrame.Height;
           writer.Open(@"C:\test.avi",w, h);
           videoFrame.Save(i + ".bmp");
           // dispose the frame when it is no longer required
           //videoFrame.Dispose();
       }
       catch (Exception ex)
       {
       //show my exception
       }
    }
