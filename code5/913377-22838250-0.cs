    async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
    {
      Bitmap imageBitmap = null;
      try {
        using (var webClient = new WebClient())
        {
          var imageBytes = await webClient.DownloadDataTaskAsync(url);
          if (imageBytes != null && imageBytes.Length > 0)
          {
            imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, 
                imageBytes.Length);
          }
      } catch (Exception ex) {
        Log.WriteLine (LogPriority.Error, "GetImageFromBitmap Error", ex.Message);
      }
      return imageBitmap;
    }
