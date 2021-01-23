    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("FILENAME.bmp", true);
    byte[,] PixelArray = new byte[bitmap.Width,bitmap.Height];
    
    int x,y;
    
    for (x = 0; x < bitmap.Width; x++)
    {
        for (y = 0; y < bitmap.Height; y++)
        {
            PixelArray[x,y] = bitmap.GetPixel(x,y);
        }
    }
