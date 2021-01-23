    /// <summary>
    /// Captures a controls visual and saves it to the file system.
    /// </summary>
    /// <param name="visual">A reference to the <see cref="Visual"/> that you want to capture.</param>
    /// <param name="fileName">The file name that you want the image saved as.</param>
    void CaptureImage(Visual visual, string fileName)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);
    
        using (FileStream fileStream = new FileStream(fileName, FileMode.CreateNew))
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)Width, (int)Height, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(this);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            encoder.Save(fileStream);
        }
    }
