    int lowerBound = 3*(int)((float)lowerBoundPercent * 255.0 / 100.0);
    int upperBound = 3*(int)((float)upperBoundPercent * 255.0 / 100.0);
    
    System.Drawing.Bitmap bp = bitmap.Processed;
    
    int width = bitmap.Width;
    int height = bitmap.Height;
            
    Rectangle rect = new Rectangle(0, 0, width, height);
    System.Drawing.Imaging.BitmapData bpData = bp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bp.PixelFormat);
    unsafe
    {
        byte* s0 = (byte*)bpData.Scan0.ToPointer();
        int stride = bpData.Stride;
        
        Parallel.For(0, height, y1 =>
        {
            int posY = y1 * stride;
            byte* cpp = s0 + posY;
            for (int x =0; x<width; x++)
            {
                int total = cpp[0] + cpp[1] + cpp[2];
                if (total >= lowerBound && total <= upperBound)
                {
                    cpp[0] = 255;
                    cpp[1] = 255;
                    cpp[2] = 255;
                    cpp[3] = 255;
                }
                else
                {
                    cpp[0] = 0;
                    cpp[1] = 0;
                    cpp[2] = 0;
                    cpp[3] = 255;
                }
                
                cpp += 4;
            }
        });
    }
    bp.UnlockBits(bpData);
