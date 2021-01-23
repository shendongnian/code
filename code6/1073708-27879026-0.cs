    // Loop through the images pixels to store in array. 
                for (y = 0; y < image1.Height; y++)
                {
                    for (x = 0; x < image1.Width; x++)
                    {
                       Color p = ((Bitmap)image1).GetPixel(x, y);
                         pic[x,y] = p.ToString();
                    }
                }
