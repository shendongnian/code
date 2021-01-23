    public Image ConvertImage(Image image)
    {
       MemoryStream convertedImageMemoryStream;
       using (MemoryStream sourceImageStream = new MemoryStream())
       {
           image.Save(sourceImageStream, System.Drawing.Imaging.ImageFormat.Png);
           byte[] sourceImagePixels = sourceImageStream.ToArray();
           // Send it to dll and get the IntPtr byte array from dll
           byte[] imagePixels = new byte[imInfo.size];
           Marshal.Copy(imInfo.data, imagePixels, 0, imInfo.size);
           if (imInfo.data != IntPtr.Zero)
               AlgorithmCpp.ReleaseMemoryFromC(imInfo.data);
           convertedImageMemoryStream = new MemoryStream(imagePixels);
        }
        Image processed = new Bitmap(convertedImageMemoryStream);
        return processed;
    }
