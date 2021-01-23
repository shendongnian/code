    using (MagickImage vertical=images.AppendVertically())
    {
      vertical.Format = MagickFormat.Jpeg;
      vertical.Write(context.Response.OutputStream);
    }
