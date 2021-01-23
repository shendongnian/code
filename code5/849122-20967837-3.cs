    var bmp = new Bitmap(width, height);
    
    var data = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    Marshal.Copy(bytes, 0, data.Scan0, width * height * 4);
    bmp.UnlockBits(data);
