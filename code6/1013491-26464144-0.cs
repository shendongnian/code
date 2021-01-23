    int page = 0;
    while (true)
    {
      MagickReadSettings settings = new MagickReadSettings()
      {
        FrameIndex = page
      };
      try
      {
        using (MagickImage image = new MagickImage(@"C:\YourFile.pdf", settings))
        {
          // Do something with the image....
        }
      }
      catch (MagickException ex)
      {
        if (ex.Message.Contains("Requested FirstPage is greater"))
          break;
        else
          throw;
      }
      page++;
    } 
