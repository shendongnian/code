    using (MagickImageCollection col = new MagickImageCollection(@"C:/PathToGif"))
    {
      col.Coalesce();
      AddOtherImages(col);
      col.Optimize();
      col.OptimizeTransparency();
      col.Write(@"C:/Path/To/Output");
    }
