    var img = new Image<Gray, byte>(10, 10);
    Bitmap bmp = img.Bitmap;
    ColorPalette pal = bmp.Palette;
    pal.Entries[0] = Color.FromArgb(255, 0, 0, 255);
    bmp.Palette = pal;
    Image<Gray, byte> changedImage = new Image<Gray, byte>(bmp);
