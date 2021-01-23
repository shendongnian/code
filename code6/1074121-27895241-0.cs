    bool isColor = IsColor(bmp);
    
    private bool IsColor(Bitmap bmp)
    {
        for (int x = 0; x < bmp.Width - 1; x++)
        {
            for (int y = 0; y < bmp.Height - 1; y++)
            {
                Color c = bmp.GetPixel(x, y);
                if (!(c.R == c.B && c.R == c.G))
                    return true;
            }
        }
        return false;
    }
