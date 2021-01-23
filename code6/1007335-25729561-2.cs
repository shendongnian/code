    using (MagickImageCollection images = new MagickImageCollection())
    {
      // Add the first image
      MagickImage first = new MagickImage("Snakeware.png");
      images.Add(first);
    
      // Add the second image
      MagickImage second = new MagickImage("Snakeware.png");
      images.Add(second);
      
      // Create an Average from both images
      using (MagickImage result = images.Evaluate(EvaluateOperator.Mean))
      {
        // Save the result
        result.Write("Mean.png");
      }
    }
