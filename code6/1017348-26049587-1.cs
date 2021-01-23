     minY = getMinY(fastBitmap, indexToRemove);
     maxY = getMinY(fastBitmap, indexToRemove);
     minX = getMinY(fastBitmap, indexToRemove);
     maxX = getMinY(fastBitmap, indexToRemove);
     int getMinY(Bitmap bitmap, byte indexToRemove)
     {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (fastBitmap.GetPixel(x, y).B == indexToRemove)
                {
                    return y;
                }
            }
        }
        return 0;
     }
     int getMaxY(Bitmap bitmap, byte indexToRemove)
     {
        for (int y = height; y > 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                if (fastBitmap.GetPixel(x, y).B == indexToRemove)
                {
                    return y;
                }
            }
        }
        return height;
     }
