    //bytes 84 21 ==> 0x8421 (LE) ==bin==> 1000 0100 0010 0001 ==split==> 10000 10000 10000 1 ==dec==> 16 16 16 1 (RGBA) ==adjust==> 128 128 128 255
    private static PixelFormatter SixteenBppFormatter = new PixelFormatter(2, 5, 11, 5, 6, 5, 1, 1, 0, true);
    
    protected static Byte[] Convert16bTo32b(Byte[] imageData, Int32 startOffset, Int32 entries)
    {
        Byte[] newImageData = new Byte[entries*4];
        for (Int32 i = 0; i < entries; i++)
        {
            Color c = SixteenBppFormatter.GetColor(imageData, startOffset + (i * 2));
            PixelFormatter.Format32BitArgb.WriteColor(newImageData, i * 4, c);
        }
        return newImageData;
    }
