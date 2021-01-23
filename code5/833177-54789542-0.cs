    public static iTextSharp.text.Font GetFontAwesome()
    {
    string fontName = "fontawesome";
    if (!FontFactory.IsRegistered(fontName))
    {
    var fontPath = System.Web.Hosting.HostingEnvironment.MapPath("\\") + "fonts\\fontawesome-webfont.ttf";
    FontFactory.Register(fontPath, fontName);
    }
        
    var FontColour = new BaseColor(0, 0, 0); // optional... ints 0, 0, 0 are red, green, blue
    int FontStyle = iTextSharp.text.Font.NORMAL;  // optional
    float FontSize = iTextSharp.text.Font.DEFAULTSIZE;  // optional
        
    return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, FontSize, FontStyle, FontColour );
     // last 3 arguments can be removed
    }
