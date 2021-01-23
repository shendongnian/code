            var pixels = new Color[img.Height*img.Width];
            for (int row = 0; row < img.Height; row++)
            {
                for (int col = 0; col < img.Width; col++)
                {
                    pixels[row + col] = img.GetPixel(col, row);
                }
            }
