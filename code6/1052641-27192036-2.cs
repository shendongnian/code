    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders(); 
    ImageCodecInfo ici = null; 
    foreach (ImageCodecInfo codec in codecs)
    { 
        if (codec.MimeType == "image/jpeg") 
        ici = codec; 
    } 
    
    EncoderParameters ep = new EncoderParameters(); 
    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100); 
    bm.Save("C:\\quality" + x.ToString() + ".jpg", ici, ep);
