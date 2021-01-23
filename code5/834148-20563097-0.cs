        public void SaveToMediaLibrary(WriteableBitmap bitmap, string name, int quality)
    {
        using (var stream = new MemoryStream())
        {
            try
            {
               // Save the picture to the Windows Phone media library.
               bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
               stream.Seek(0, SeekOrigin.Begin);
               new MediaLibrary().SavePicture(name, stream);
            }
            catch(UnauthorizedAccessException uae)
            {
              // log the exception message, uae.Message, in your favourite way :)
            }
        }
    }
