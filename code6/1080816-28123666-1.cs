    public static Color getDominantColor(Bitmap bmp)
            {
                //Used for tally
    			int red = 0;
    			int green = 0;
    			int blue = 0;
    
    			int acc = 0;
    
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
    					Color tmpColor = bmp.GetPixel(x, y);
    
                        red += tmpColor.R;
                        green += tmpColor.G;
                        blue += tmpColor.B;
    
                        acc++;
                    }
                }
    
                //Calculate average
                red /= acc;
                green /= acc;
                blue /= acc;
    
                return Color.FromArgb(red, green, blue);
            }
