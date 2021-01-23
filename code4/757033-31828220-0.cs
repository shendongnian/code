    private static void Split(string fileName, int width, int height)
    {
        using (Bitmap source = new Bitmap(fileName))
        {
            bool perfectWidth = source.Width % width == 0;
            bool perfectHeight = source.Height % height == 0;
    
            int lastWidth = width;
            if (!perfectWidth)
            {
                lastWidth = source.Width - ((source.Width / width) * width);
            }
    
            int lastHeight = height;
            if (!perfectHeight)
            {
                lastHeight = source.Height - ((source.Height / height) * height);
            }
    
            int widthPartsCount = source.Width / width + (perfectWidth ? 0 : 1);
            int heightPartsCount = source.Height / height + (perfectHeight ? 0 : 1);
    
            for (int i = 0; i < widthPartsCount; i++)
                for (int j = 0; j < heightPartsCount; j++)
                {
                    int tileWidth = i == widthPartsCount - 1 ? lastWidth : width;
                    int tileHeight = j == heightPartsCount - 1 ? lastHeight : height;
                    using (Bitmap tile = new Bitmap(tileWidth, tileHeight))
                    {
                        using (Graphics g = Graphics.FromImage(tile))
                        {
                            g.DrawImage(source, new Rectangle(0, 0, tile.Width, tile.Height), new Rectangle(i * width, j * height, tile.Width, tile.Height), GraphicsUnit.Pixel);
                        }
    
                        tile.Save(string.Format("{0}-{1}.png", i + 1, j + 1), ImageFormat.Png);
                    }
                }
        }
    }
