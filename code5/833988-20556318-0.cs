    public static class CanvasExtender
    {
      public static void SaveToImageFile(this Canvas canvas, string outputFile)
      {
        canvas.UpdateLayout();
        var bitmap = new RenderTargetBitmap(canvas.ActualWidth, canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
        bitmap.Render(canvas);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        
        using(var outputStream = File.Create(outputFile))
          encoder.Save(outputStream);
      }
    }
