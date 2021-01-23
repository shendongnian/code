    // Model
    public List<FontFamily> Fonts { get; set; }
    // Controller 
    List<FontFamily> liFonts = new List<FontFamily>();
    foreach (FontFamily font in System.Drawing.FontFamily.Families)
    {
         liFonts.Add(font.Name);
    }
