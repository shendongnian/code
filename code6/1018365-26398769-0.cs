    private Color TRANSPARENT = Color.Transparent;
    private Color BAD_COLOR = Color.Purple;
    private const int DEVIATION = 10;
    public Texture2D trimImage(Texture2D texture)
    {
        /// Get the data from the original texture and place it in an array
        Color[] colorData = new Color[texture.Width * texture.Height];
        texture.GetData<Color>(colorData);
        /// Loop through the array and change the RGB values you choose
        for (int x = 0; x < texture.Width; x++)
        {
            for (int y = 0; y < texture.Height; y++)
            {
                Color pixel = colorData[x * texture.Height + y];
                /// Check if the color is within the range
                if (MathHelper.Distance(pixel.R, BAD_COLOR.R) < DEVIATION &&
                    MathHelper.Distance(pixel.G, BAD_COLOR.G) < DEVIATION &&
                    MathHelper.Distance(pixel.B, BAD_COLOR.B) < DEVIATION &&
                    pixel.A != 0f)
                {
                    /// Make that color transparent
                    pixel = TRANSPARENT;
                }
            }
        }
        /// Put the color array into the new texture and return it
        texture.SetData<Color>(colorData);
        return texture;
    }
