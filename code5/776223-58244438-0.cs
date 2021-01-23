    MemoryStream msSave = new MemoryStream();
    ImageCodecInfo pngCodec = ImageCodecInfo
        .GetImageEncoders()
        .Where(codec => codec.FormatID.Equals(ImageFormat.Png.Guid))
        .FirstOrDefault();
    
    if (pngCodec != null)
    {
        EncoderParameters parameters = new EncoderParameters();
        parameters.Param[0] = new EncoderParameter(Encoder.ColorDepth, 256L);
        img.Save(msSave, pngCodec, parameters);
    }
    
    img.Save(msSave, imageFormat);
