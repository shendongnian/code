    private byte[] ResizeImage2(string resizeInfo)
    {
      string[] picInfo = resizeInfo.Split('|');
      int width = int.Parse(picInfo[0]);
      int height = int.Parse(picInfo[1]);
      int targetWidth = int.Parse(picInfo[2]);
      int targetHeight = int.Parse(picInfo[3]);
      int x = int.Parse(picInfo[4]);
      int y = int.Parse(picInfo[5]);
    
      using (var fileStore = new EPMLiveFileStore(Web))
      {
        using (Bitmap sourceImage = new Bitmap(fileStore.GetStream(FileNameField.Value)))
        {
          using (var bitmap = new Bitmap(width, height))
          {
            bitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
    
            using (var graphics = Graphics.FromImage(bitmap))
            {
              graphics.DrawImageUnscaled(sourceImage, Point.Empty);
              using (var memoryStream = new MemoryStream())
              {
                  bitmap.Save(memoryStream, ImageFormat.Png);
                  return (byte[]) memoryStream.ToArray();
              }
            }
          }
        }
      }
    }
