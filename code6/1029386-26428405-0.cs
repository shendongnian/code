    ImageCodecInfo codec;
    EncoderParameters myEPS;
    public YourConstructor() {
        
        codec = GetEncoder(ImageFormat.Jpeg);
        myEPS = new EncoderParameters(1);
        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        EncoderParameter myEP = new EncoderParameter(myEncoder, 60L); // 0-100 quality level
        myEPS.Param[0] = myEP;
    
    }
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
    	ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    
    	foreach (ImageCodecInfo codec in codecs)
    	{
    		if (codec.FormatID == format.Guid)
    		{
    			return codec;
    		}
    	}
    	return null;
    }
    public static byte[] GetBytesFromImage(Image img)
    {
    	if (img == null) return null;
    	using (MemoryStream stream = new MemoryStream())
    	{
    		img.Save(stream, codec, myEPS);
    		return stream.ToArray();
    	}
    }
