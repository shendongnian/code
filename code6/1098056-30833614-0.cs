    public Texture2D AddWatermark(Texture2D background, Texture2D watermark)
    {
        int startX = 0;
        int startY = background.height - watermark.height;
        for (int x = startX; x < background.width; x++)
        {
            
            for (int y = startY; y < background.height; y++)
            {
                Color bgColor = background.GetPixel(x, y);
                Color wmColor = watermark.GetPixel(x - startX, y - startY);
                Color final_color = Color.Lerp(bgColor, wmColor, wmColor.a / 1.0f);
                background.SetPixel(x, y, final_color);
            }
        }
        background.Apply();
        return background;
    }
