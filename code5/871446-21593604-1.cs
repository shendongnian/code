    public static void SaveJpegImage(System.Drawing.Image image, string fileName)
    {
        ImageCodecInfo codecInfo = ImageCodecInfo.GetImageEncoders()
            .Where(r => r.CodecName.ToUpperInvariant().Contains("JPEG"))
            .Select(r => r).FirstOrDefault();
        var encoder = System.Drawing.Imaging.Encoder.Quality;
        var parameters = new EncoderParameters(1);
        var parameter = new EncoderParameter(encoder, 90L);
        parameters.Param[0] = parameter;
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            image.Save(fs, codecInfo, parameters);
        }
    }
 
