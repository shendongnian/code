    class PixelHelper
    {
        public Point Coordinate;
        public Color PixelColor;
    }
    PixelHelper[] pixelBackup = new PixelHelper[300];
    Random r = new Random();
    for (int i = 0; i < 300; i++)
    {
        int xRandom = r.Next(bmp.Width);
        int yRandom = r.Next(bmp.Height);
        Color c = bmp.GetPixel(xRandom, yRandom);
        PixelHelper[i] = new PixelHelper() { Point = new Point(xRandom, yRandom), PixelColor = c };
    }
