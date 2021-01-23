    Texture2D BitmapToTexture(Bitmap bmap)
    {
        Color[] colors = new Color[bmap.Width * bmap.Height];
        for (int x = 0; x < bmap.Width; x++)
        {
            for (int y = 0; y < bmap.Height; y++)
            {
                int index = x + y * bmap.Width;
                Vector4 colorVector =
                    new Vector4((float)x / 255f, (float)x / 255f, (float)x / 255f, 1);
                colors[index] = Color.FromNonPremultiplied(colorVector);
            }
        }
        Texture2D texture = new Texture2D(GraphicsDevice, bmap.Width, bmap.Height);
        texture.SetData<Vector4>(colors);
        return texture;
    }
