    public void GenerateNoise(Image img, int intense)
            {
                Bitmap finalBmp = img as Bitmap;
                Random r = new Random();
                int width = img.Width;
                int height = img.Height;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int def = r.Next(0, 100);
                        if (def < intense)
                        {
                            int op = r.Next(0, 1);
                            if (op == 0)
                            {
                                int num = r.Next(0, intense);
                                Color clr = finalBmp.GetPixel(x, y);
                                int R = (clr.R + clr.R + num)/2;
                                if (R > 255) R = 255;
                                int G = (clr.G + clr.G + num) / 2;
                                if (G > 255) G = 255;
                                int B = (clr.B + clr.B + num) / 2;
                                if (B > 255) B = 255;
                                Color result = Color.FromArgb(255, R, G, B);
                                finalBmp.SetPixel(x, y, result);
                            }
                            else
                            {
                                int num = r.Next(0, intense);
                                Color clr = finalBmp.GetPixel(x, y);
                                Color result = Color.FromArgb(255, (clr.R + clr.R - num) / 2, (clr.G + clr.G - num) / 2,
                                    (clr.B + clr.B - num) / 2);
                                finalBmp.SetPixel(x, y, result);
                            }
                        }
                    }
                }
                
            }
