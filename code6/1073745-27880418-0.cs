    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bitmap = new Bitmap("Image.bmp");
            Bitmap red = new Bitmap(bitmap.Width, bitmap.Height);
            Bitmap blue = new Bitmap(bitmap.Width, bitmap.Height);
            Bitmap green = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color c = bitmap.GetPixel(x, y);
                    red.SetPixel(x, y, Color.FromArgb(c.R, 0, 0));
                    blue.SetPixel(x, y, Color.FromArgb(0, 0, c.B));
                    green.SetPixel(x, y, Color.FromArgb(0, c.G, 0));
                }
            }
            
            // - Don't forget to save, until now we're only messing with the loaded memory of the bitmap.
            red.Save("Red.bmp");
            blue.Save("Blue.bmp");
            green.Save("Green.bmp");
        }        
    }
