    private byte[] ResizeImage2(string resizeInfo)
    {
        string[] picInfo = resizeInfo.Split('|');
        int width = int.Parse(picInfo[0]);
        int height = int.Parse(picInfo[1]);
        int targetWidth = int.Parse(picInfo[2]);
        int targetHeight = int.Parse(picInfo[3]);
        int x = int.Parse(picInfo[4]);
        int y = int.Parse(picInfo[5]);
        byte[] rslt;
        Bitmap sourceImage;
        using (var fileStore = new EPMLiveFileStore(Web))
        {
            sourceImage = new Bitmap(fileStore.GetStream(FileNameField.Value));
        }
        using (var bitmap = new Bitmap(targetWidth, targetHeight))
        {
            bitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, targetWidth, targetHeight), new Rectangle(x, y, targetWidth, targetHeight), GraphicsUnit.Pixel);
                using (var memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    rslt = memoryStream.ToArray();
                }
            }
        }
        return rslt;
    }
