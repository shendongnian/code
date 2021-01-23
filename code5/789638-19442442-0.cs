    Color Combine(Color left, Color right)
    {
        return new Color(left.Red, right.Green, right.Blue);
    }
    Image Combine(Image left, Image right)
    {
        Image result = new Image(left.Width, left.Height);
        for (int y = 0; y < left.Height; y++)
        for (int x = 0; x < left.Width; x++)
        {
            result.SetPixel(x, y, Combine(left.GetPixel(x, y), right.GetPixel(x, y)));
        }
    }
