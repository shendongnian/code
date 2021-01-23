    public ImageSource CreateBitmap(int width, int height)
    {
        int stride = (width + 7) / 8;
        var pixels = new byte[height * stride];
        for (int i = 0; i < height * stride; i++)
        {
            pixels[i] = 0xAA;
        }
        var format = PixelFormats.Indexed1;
        var colors = new List<Color> { Colors.Black, Colors.White };
        var palette = new BitmapPalette(colors);
        var bitmap = new WriteableBitmap(width, height, 96, 96, format, palette);
        bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, stride, 0);
        return bitmap;
    }
