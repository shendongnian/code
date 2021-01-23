    static bool IntersectPixels(Rectangle rectangleA, Bitmap bmpA,
                                Rectangle rectangleB, Bitmap bmpB)
    {
        bool collision = false;
        Size s1 = bmpA.Size;
        Size s2 = bmpB.Size;
        PixelFormat fmt1 = bmpA.PixelFormat;
        PixelFormat fmt2 = bmpB.PixelFormat;
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        Rectangle rectB = new Rectangle(0, 0, s2.Width, s2.Height);
        BitmapData bmp1Data = bmpA.LockBits(rect, ImageLockMode.ReadOnly, fmt1);
        BitmapData bmp2Data = bmpB.LockBits(rectB, ImageLockMode.ReadOnly, fmt2);
        int size1 = bmp1Data.Stride * bmp1Data.Height;
        int size2 = bmp2Data.Stride * bmp2Data.Height;
        byte[] data1 = new byte[size1];
        byte[] data2 = new byte[size2];
        System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1);
        System.Runtime.InteropServices.Marshal.Copy(bmp2Data.Scan0, data2, 0, size2);
        // Find the bounds of the rectangle intersection
        int top = Math.Max(rectangleA.Top, rectangleB.Top);
        int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
        int left = Math.Max(rectangleA.Left, rectangleB.Left);
        int right = Math.Min(rectangleA.Right, rectangleB.Right);
        // Check every point within the intersection bounds
        for (int y = top; y < bottom; y++)
        {
            for (int x = left; x < right; x++)
            {
                // Color data are BGRA!
                // Get the alpha (+3!) value of both pixels at this point
                byte colorA = data1[(x - rectangleA.Left) +  
                                    (y - rectangleA.Top) * rectangleA.Width + 3];
                byte colorB = data2[(x - rectangleB.Left) + 
                                    (y - rectangleB.Top) * rectangleB.Width + 3];
                // If both pixels are not completely transparent,
                if (colorA != 0 && colorB != 0)
                {
                    // then an intersection has been found
                    { collision = true; goto done; }
                }
            }
        }
      done:
        bmpA.UnlockBits(bmp1Data);
        bmpB.UnlockBits(bmp2Data);
        return collision;
    }
