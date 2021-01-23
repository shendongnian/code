           //plyImage is a Bitmap with player's image, maskImage is a bitmap with the circle mask
           for (int y = 0; y < plyImage.Height; y++)
            {
                for (int x = 0; x < plyImage.Width; x++)
                {
                    Color srcColor = plyImage.GetPixel(x, y);
                    Color maskColor = maskImage.GetPixel(x, y);
                    Color finalColor = Color.FromArgb(maskColor.A, srcColor.R, srcColor.G, srcColor.B);
                    plyImage.SetPixel(x, y, finalColor);
                }
            }
