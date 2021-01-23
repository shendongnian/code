    if (e.NativeData != IntPtr.Zero)
    {
        Bitmap img = null;
        if (this._commands.CheckForDebug())
        {
            Console.WriteLine("Image data transferred.");
        }
        //Need to save out the data.
        img = e.NativeData.GetDrawingBitmap();
        if (img != null)
        {
             string fileName = "RandomFileName.";
             
             string fileType = this._commands.GetFileType();
             switch (fileType)
             {
                 case "png":
                    fileName += "png";
                    ImageExtensions.SavePNG(img, fileName, 50L);
                    break;
                 case "jpeg":
                    fileName += "jpeg";
                    ImageExtensions.SaveJPEG(img, fileName, 50L);
                    break;
                 default:
                    fileName += "png";
                    ImageExtensions.SavePNG(img, fileName, 50L);
                    break;
              }
        }
    }
    public static void SaveJPEG(Image img, string filePath, long quality)
        {
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,   quality);
            img.Save(filePath, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }
