    for (int x = 0; x < bmp.Width; x++)
     {
        for (int y = 0; y < bmp.Height; y++)
        {
           byte tempR, tempG, tempB = 0;
           tempR = Convert.ToByte(splitRGB[x][0]);
           tempG = Convert.ToByte(splitRGB[x][1]);
           tempB = Convert.ToByte(splitRGB[x][2]);
           Color pixel = Color.FromArgb(tempR,tempG,tempB);
           bmp.SetPixel(x, y, pixel);
        }
     }
