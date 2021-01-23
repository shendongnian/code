        public static Texture2D AddWatermark(Texture2D background, Texture2D watermark, int startPositionX, int startPositionY)
        {
            //only read and rewrite the area of the watermark
            for (int x = startPositionX; x < background.width; x++)
            {
                for (int y = startPositionY; y < background.height; y++)
                {
                    if (x - startPositionX < watermark.width && y - startPositionY < watermark.height)
                    {
                        var bgColor = background.GetPixel(x, y);
                        var wmColor = watermark.GetPixel(x - startPositionX, y - startPositionY);
                        var finalColor = Color.Lerp(bgColor, wmColor, wmColor.a / 1.0f);
                        background.SetPixel(x, y, finalColor);
                    }
                }
            }
            background.Apply();
            return background;
        }
