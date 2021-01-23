    public static Bitmap MakeGrayscale2(Bitmap original)
    {
       unsafe
       {
          //create an empty bitmap the same size as original
          Bitmap newBitmap = new Bitmap(original.Width, original.Height);
    
          //lock the original bitmap in memory
          BitmapData originalData = original.LockBits(
             new Rectangle(0, 0, original.Width, original.Height),
             ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    
          //lock the new bitmap in memory
          BitmapData newData = newBitmap.LockBits(
             new Rectangle(0, 0, original.Width, original.Height), 
             ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
    
          //set the number of bytes per pixel
          int pixelSize = 3;
    
          for (int y = 0; y < original.Height; y++)
          {
             //get the data from the original image
             byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);
    
             //get the data from the new image
             byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);
    
             for (int x = 0; x < original.Width; x++)
             {
                //create the grayscale version
                byte grayScale = 
                   (byte)((oRow[x * pixelSize] * .11) + //B
                   (oRow[x * pixelSize + 1] * .59) +  //G
                   (oRow[x * pixelSize + 2] * .3)); //R
    
                //set the new image's pixel to the grayscale version
                nRow[x * pixelSize] = grayScale; //B
                nRow[x * pixelSize + 1] = grayScale; //G
                nRow[x * pixelSize + 2] = grayScale; //R
             }
          }
    
          //unlock the bitmaps
          newBitmap.UnlockBits(newData);
          original.UnlockBits(originalData);
    
          return newBitmap;
       }
    }
