    private BitmapFrame GetSizedSource(Icon icon, int size)
    {
       using (var stream = new MemoryStream())
       {
          icon.Save(stream);
          stream.Position = 0;
          return BitmapDecoder.Create(stream, BitmapCreateOptions.DelayCreation, BitmapCacheOption.OnDemand)
                    .Frames
                    .SingleOrDefault(_ => Math.Abs(_.Width - size) < double.Epsilon);
       }
    }
