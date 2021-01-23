    public static Image<TColor, byte> Bla<TColor>(this Image<TColor, byte> img, bool inPlace = true)
        where TColor : IColor
    {
        if (img is IColor3)
        {
            //do something
        }
        if (img is IColor4)
        {
            //do something
        }
    }
