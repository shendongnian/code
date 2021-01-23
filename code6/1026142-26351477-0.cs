    using System.Windows.Media.Imaging;
    using System.IO;
    private WriteableBitmap ConvertToGrayScale(BitmapImage source)
    {
        WriteableBitmap wb = new WriteableBitmap(source);               // create the WritableBitmap using the source
        int[] grayPixels = new int[wb.PixelWidth * wb.PixelHeight];
        // lets use the average algo 
        for (int x = 0; x < wb.PixelWidth; x++)
        {
            for (int y = 0; y < wb.PixelHeight; y++)
            {
                // get the pixel
                int pixel = wb.Pixels[y * wb.PixelWidth + x];
                
                // get the component
                int red   = (pixel & 0x00FF0000) >> 16;
                int blue  = (pixel & 0x0000FF00) >> 8;
                int green = (pixel & 0x000000FF);
                // get the average
                int average = (byte)((red + blue + green) / 3);   
             
                // assign the gray values keep the alpha
                unchecked
                {
                    grayPixels[y * wb.PixelWidth + x] = (int)( (pixel & 0xFF000000) | average << 16 | average << 8 | average);
                }
                
            }
        }
        // copy grayPixels back to Pixels
        Buffer.BlockCopy(grayPixels, 0, wb.Pixels, 0, (grayPixels.Length * 4));
        
        return wb;            
    }
    private BitmapImage ConvertWBtoBI(WriteableBitmap wb)
    {
        BitmapImage bi;
        using (MemoryStream ms = new MemoryStream())
        {
            wb.SaveJpeg(ms, wb.PixelWidth, wb.PixelHeight, 0, 100);
            bi = new BitmapImage();
            bi.SetSource(ms);
        }
        return bi;
    }
----------
    <Image x:Name="myImage" Source="/Assets/AlignmentGrid.png" Stretch="None" />
