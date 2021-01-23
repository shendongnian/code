    using (MagickImage sprite = images.AppendHorizontally())
    {
      sprite.Format = MagickFormat.Jpeg;
      sprite.Quality = 10;
      sprite.Resize(40, 40);
      sprite.Write(spriteFile);
    }
