    //quality of the compressed image
    long quality = 50;
    
    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders(); 
    ImageCodecInfo ici = null; 
    
    foreach (ImageCodecInfo codec in codecs)
    { 
        if (codec.MimeType == "image/jpeg") 
        ici = codec; 
    } 
    
    EncoderParameters ep = new EncoderParameters();
    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
    
    using (var testStream = new MemoryStream())
    {
        b.Save(testStream, ici, ep);
        long streamSize = testStream.Length;
    }
