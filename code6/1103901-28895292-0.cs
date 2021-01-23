        public static Bitmap MakeTransparent(Image image)
        {
            Bitmap b = new Bitmap(image);
            var replacementColour = Color.FromArgb(255, 255, 255);
            var tolerance = 10;
            for (int i = b.Size.Width - 1; i >= 0; i--)
            {
                for (int j = b.Size.Height - 1; j >= 0; j--)
                {
                    var col = b.GetPixel(i, j);
                    if (255 - col.R < tolerance && 
                        255 - col.G < tolerance && 
                        255 - col.B < tolerance)
                    {
                        b.SetPixel(i, j, replacementColour);
                    }
                }
            }
            b.MakeTransparent(replacementColour);
            return b;
        }
