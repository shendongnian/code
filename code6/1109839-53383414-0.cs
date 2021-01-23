    PictureBox.Image = CaptureControl(PictureBox.Handle, PictureBox.Width, PictureBox.Height);
    // PictureBox.Image now contains the data that was drawn to it
    
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        public Bitmap CaptureControl(IntPtr handle, int width, int height)
        {
          Bitmap controlBmp;
          using (Graphics g1 = Graphics.FromHwnd(handle))
          {
            controlBmp = new Bitmap(width, height, g1);
            using (Graphics g2 = Graphics.FromImage(controlBmp))
            {
             g2.CopyFromScreen(this.Location.X + PictureBox.Left, this.Location.Y + PictureBox.Top, 0, 0, PictureBox.Size);
    
              IntPtr dc1 = g1.GetHdc();
              IntPtr dc2 = g2.GetHdc();
    
              BitBlt(dc2, 0, 0, width, height, handle, 0, 0, 13369376);
              g1.ReleaseHdc(dc1);
              g2.ReleaseHdc(dc2);
            }
          }
    
          return controlBmp;
        }
