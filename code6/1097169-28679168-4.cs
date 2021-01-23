    static bool IntersectPixels(Rectangle rectangleA, Bitmap bmpA,  Rectangle rectangleB)
    {
        bool collision = false;
        Size s1 = bmpA.Size;
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        rectangleB.Intersect(rectangleA);
        BitmapData bmp1Data = bmpA.LockBits(rect, ImageLockMode.ReadOnly, bmpA.PixelFormat);
        int size1 = bmp1Data.Stride * bmp1Data.Height;
        byte[] data1 = new byte[size1];
        System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1);
        // Check every point within the intersection bounds
        for (int y = rectangleB.Top; y < rectangleB.Bottom; y++)
        {
            for (int x = rectangleB.Left; x < rectangleB.Right; x++)
            {
                // Get the alpha value of both pixels at this point
                byte colorA = data1[(x - rectangleA.Left) + 
                                    (y - rectangleA.Top) * rectangleA.Width + 3];
                // If a non-tranparent pixel
                if (colorA != 0 )   { collision = true; goto done; }
            }
        }
    done:
        bmpA.UnlockBits(bmp1Data);
        return collision;
    }
