    unsafe
    {
       BitmapData bitmapData = ImageOut.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
 
       byte[] pixels = new byte[bmp.Width * bmp.Height * 4]; //4 means 1 byte for each a r g b
       IntPtr ptr = bitmapData.Scan0;
       Marshal.Copy(ptr , pixels, 0, pixels.Length);
       for (int y = 0; y < bmpData.Height; y++)
       {
            byte* row = (byte*)bmpData.Scan0 + (y * bmpData.Stride);
            for (int x = 0; x < bmpData.Width; x++)
            {
                int offSet = x * PixelSize;
                // read pixels
                byte blue = row[offSet];
                byte green = row[offSet + 1];
                byte red = row[offSet + 2];
                byte alpha = row[offSet + 3];
                
                //copy to target
                pixels[offSet] = blue;
                pixels[offSet + 1] = green;
                pixels[offSet + 2] = red;
                pixels[offSet + 3] = alpha;
            }
        }
        bitmapData.UnlockBits();
    }
    //set to picturebox
    pictureBox.Image = ImageOut;
