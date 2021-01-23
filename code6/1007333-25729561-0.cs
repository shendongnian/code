    using (MagickImageCollection images = new MagickImageCollection())
    {
      // Add the first image
      MagickImage first = new MagickImage("Snakeware.png");
      images.Add(first);
    
      // Add the second image
      MagickImage second = new MagickImage("Snakeware.png");
      images.Add(second);
      
      // Create a mosaic from both images
      using(MagickImage result = images.Mosaic())
      {
        // Save the result
        result.Write("Mosaic.png");
      }
    }
