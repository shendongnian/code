    using (MagickImage image = new MagickImage("input.png"))
    {
      // Set the format and write to a stream so ImageMagick won't detect the file type.
      image.Format = MagickFormat.Pjpeg;
      using (FileStream fs = new FileStream("output.jpg", FileMode.Create))
      {
        image.Write(fs);
      }
      // Write to .jpg file
      image.Write("PJEG:output.jpg");
      // Or to a .pjpeg file
      image.Write("output.pjpg");
    }
