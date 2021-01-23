    public static Bitmap MakePlaceholderImage(Int32 width, Int32 height)
    {
        Bitmap bm = new Bitmap(width, height, PixelFormat.Format1bppIndexed);
        // This colour can't be assigned directly since the .Palette getter actually makes a copy of the palette.
        ColorPalette pal = bm.Palette;
        pal.Entries[0] = Color.Transparent;
        bm.Palette = pal;
        return bm;
    }
