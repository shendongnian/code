        public Bitmap GrabScreenshot()
        {
 
            Bitmap bmp = new Bitmap(Width, Height);
            System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(otkViewport.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);
 
            GL.Finish();
            GL.ReadPixels(0, 0, this.otkViewport.Width, this.otkViewport.Height, PixelFormat.Bgr, PixelType.UnsignedByte,  data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }
