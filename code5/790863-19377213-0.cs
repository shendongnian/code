        // Receive bytes from a Device
            board.ReadBytes((int)0xA0, 1024 * 30, ref data_Array1); 
            //restore the 12-bit pixel values
            for (int i = 0; i < width * height; i++)  
            {
            // This is a 12-bit pixel value.    
            raw_data1[i] = (ushort)((((int)data_Array1[2 * i+1] << 8) & 0x0F00) | ((int)data_Array1[2 * i ] & 0xFF));                       
            }
            // Convert from a 12-bit array to a 8-bit array.
            raw_data_byte1 = DownScale(raw_data1); 
            //create a new Bitmap
           Bitmap bmp = new Bitmap(height, width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);                    System.Drawing.Imaging.ColorPalette pal = bmp.Palette;
           //create grayscale palette
           for (int i = 0; i < 256; i++)
           {
             pal.Entries[i] = Color.FromArgb((int)255, i, i, i);
           }
        
            //assign to bmp
            bmp.Palette = pal;
        
            //lock it to get the BitmapData Object
            System.Drawing.Imaging.BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            //copy the bytes
    System.Runtime.InteropServices.Marshal.Copy(raw_data_byte1, 0, bmData.Scan0, bmData.Stride * bmData.Height);
            //never forget to unlock the bitmap
            bmp.UnlockBits(bmData);
            //display
            this.pictureBox1.Image = bmp;
