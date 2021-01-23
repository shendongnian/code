    unsafe
        {
            byte* dst = (byte*)data.Scan0.ToPointer();
    
    
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++, src++, dst += pixelSize)
                {
                    dst[RGB.A] = input[src].A;
                    dst[RGB.R] = input[src].R;
                    dst[RGB.G] = input[src].G;
                    dst[RGB.B] = input[src].B;
                }
    
                dst += offset;
            }
        }
