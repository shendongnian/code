    Texture2D BitmapToTexture(Bitmap bmap)
    {
        Mircosoft.Xna.Framework.Color[] colors = new Color[bmap.Width * bmap.Height];
        for (int x = 0; x < bmap.Width; x++)
        {
            for (int y = 0; y < bmap.Height; y++)
            {
                int index = x + y * bmap.Width;
                System.Color color = bmap.GetPixel(x, y);
                Vector4 colorVector =
                    new Vector4((float)color.R / 255f,
                                (float)color.G / 255f,
                                (float)color.B / 255f, 1);
                colors[index] = Color.FromNonPremultiplied(colorVector);
            }
        }
        Texture2D texture = new Texture2D(GraphicsDevice, bmap.Width, bmap.Height);
        texture.SetData<Color>(colors);
        return texture;
    }
