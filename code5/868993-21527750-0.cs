    public static Bitmap GrauwertBild(Bitmap input) 
    {
      Bitmap greyscale = new Bitmap(input.Width, input.Height);
      for (int x = 0; x < input.Width; x++)
      {
        for (int y = 0; y < input.Height; y++)
        {
         Color pixelColor = input.GetPixel(x, y);
         //  0.3 · r + 0.59 · g + 0.11 · b
         int grey = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
         greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey , grey , grey ));
        }
      }
      return greyscale;
    }
