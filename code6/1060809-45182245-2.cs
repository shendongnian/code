    public Image ConvertImage(Image image)
    {
       MemoryStream convertedImageMemoryStream;
       using (MemoryStream sourceImageStream = new MemoryStream())
       {
           image.Save(sourceImageStream, System.Drawing.Imaging.ImageFormat.Png);
           byte[] sourceImageData = sourceImageStream.ToArray();
           // Send it to dll and get the IntPtr byte array from dll
           byte[] imageData = new byte[imInfo.size];
           Marshal.Copy(imInfo.data, imageData, 0, imInfo.size);
           if (imInfo.data != IntPtr.Zero)
               AlgorithmCpp.ReleaseMemoryFromC(imInfo.data);
           convertedImageMemoryStream = new MemoryStream(imageData);
        }
        Image processed = new Bitmap(convertedImageMemoryStream);
        return processed;
    }
