    public static CompareResult Compare(Bitmap bmp1, Bitmap bmp2)
    {
        CompareResult cr = CompareResult.ciCompareOk;
    
        //Test to see if we have the same size of image
        if (bmp1.Size != bmp2.Size)
        {
            cr = CompareResult.ciSizeMismatch;
        }
        else
        {
            //Sizes are the same so start comparing pixels
            for (int x = 0; x < bmp1.Width 
                 && cr == CompareResult.ciCompareOk; x++)
            {
                for (int y = 0; y < bmp1.Height 
                             && cr == CompareResult.ciCompareOk; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        cr = CompareResult.ciPixelMismatch;
                }
            }
        }
        return cr;
    }
    
