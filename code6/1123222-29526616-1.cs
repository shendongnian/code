    private unsafe Bitmap optIm2(Bitmap img)
    {
        int rows = img.Height;
        int cols = img.Width;
        var dstImg = new Bitmap(cols, rows, img.PixelFormat);
        var srcImageData = img.LockBits(new Rectangle(0, 0, cols, rows), System.Drawing.Imaging.ImageLockMode.ReadOnly, img.PixelFormat);
        var dstImageData = dstImg.LockBits(new Rectangle(0, 0, cols, rows), System.Drawing.Imaging.ImageLockMode.ReadOnly, dstImg.PixelFormat);
        try
        {
            var bitmap = new byte[rows * cols];
            var outmap = new byte[rows * cols];
            fixed (byte* ptr = &bitmap[0])
            {
                byte* pixels = (byte*)srcImageData.Scan0;
                byte* p = ptr;
                //convert to single byte grayscale
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var pixel = *pixels++;
                        pixel += *pixels++; 
                        pixel += *pixels++;
                        *p++ = (byte)(pixel / 3);  //here i dont know at all
                    }
                }
            }
            int distance = 9;
            int threshold = 7;
            //check our threshold
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (bitmap[GetXY(col, row, cols)] != 0)
                    {
                        int count = 0;
                        int x, y;
                        int dhalf = distance / 2 + 1;
                        //optimization possible here by checking inside a circle rather than square+dist
                        for (x = Math.Max(col - dhalf, 0); x < Math.Min(col + dhalf, cols); x++)
                        {
                            for (y = Math.Max(row - dhalf, 0); y < Math.Min(row + dhalf, rows); y++)
                                if ((SQ(distance) > DISTANCE(col, row, x, y)) && (bitmap[GetXY(x, y, cols)] != 0))
                                    count++;
                        }
                        if (count >= threshold)
                            outmap[GetXY(col, row, cols)] = 255;
                        else
                            outmap[GetXY(col, row, cols)] = 0;
                    }
                    else
                        outmap[GetXY(col, row, cols)] = 0;
                }
            }
            // Copy data from outmap to pixels of bitmap. Since outmap is grayscale data, we replicate it for all channels
            byte* dstPtr = (byte*)dstImageData.Scan0;
            for (int row = 0; row < rows; row++)
            {
                byte* rowPtr = dstPtr;
                for (int col = 0; col < cols; col++)
                {
                    *rowPtr++ = outmap[GetXY(col, row, cols)];
                    *rowPtr++ = outmap[GetXY(col, row, cols)];
                    *rowPtr++ = outmap[GetXY(col, row, cols)];
                }
                dstPtr += dstImageData.Stride;
            }
        }
        finally
        {
            img.UnlockBits(srcImageData);
            img.Dispose();
            dstImg.UnlockBits(dstImageData);
        }
        return dstImg;
    }
    private int GetXY(int x, int y, int w) { return ((x) + ((w) * (y))); }
    private int SQ(int a) { return ((a) * (a)); }
    private int DISTANCE(int a, int b, int c, int d) { return (SQ(a - c) + SQ(b - d)); }
