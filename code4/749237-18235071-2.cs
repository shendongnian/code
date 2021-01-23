    public static void Set5(byte* p, byte b, byte g, byte r)
    public static void Set3(byte* p, byte b, byte g, byte r)
    //usage
    public void Draw(Rectangle rect, byte b, byte g, byte r)
    {
        Action<byte*, byte, byte, byte> setRow = null;
        switch(rect.Width)
        {
            case 3: setRow = Set3; break;
            case 5: setRow = Set5; break;
            //etc
        }
        byte* p=(byte*)bmd.Scan0 + bmd.Stride * rect.Y + 3 * rect.X;
        while(p < endAddress)
        {
            setRow(p, b, g, r);
            p+=bmd.Stride;  
        }
    }
