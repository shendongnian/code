    public static iTextSharp.text.Font GetTahoma()
    {
        var fontName = "Tahoma";
        if (!FontFactory.IsRegistered(fontName))
        {
             var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
             FontFactory.Register(fontPath);
        }
        return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED); 
    }
