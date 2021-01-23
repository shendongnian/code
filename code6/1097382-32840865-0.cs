      try
      {
          return (Bitmap)Image.FromStream(stream);
      }
      catch (OutOfMemoryException)
      {
          // retry only once. If it keeps failing it may be something more serious
          GC.Collect();
          GC.WaitForFullGCComplete();
          GC.WaitForPendingFinalizers();
          GC.Collect();
          return (Bitmap)Image.FromStream(stream);
      }
