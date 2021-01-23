    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern long BitBlt (IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
    private Bitmap memoryImage;
    private void CaptureScreen()
    {
       Graphics mygraphics = this.CreateGraphics();
       Size s = this.Size;
       memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
       Graphics memoryGraphics = Graphics.FromImage(memoryImage);
       IntPtr dc1 = mygraphics.GetHdc();
       IntPtr dc2 = memoryGraphics.GetHdc();
       BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
       mygraphics.ReleaseHdc(dc1);
       memoryGraphics.ReleaseHdc(dc2);
    }
    private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
       e.Graphics.DrawImage(memoryImage, 0, 0);
    }
    private void printButton_Click(System.Object sender, System.EventArgs e)
    {
       CaptureScreen();
       printDocument1.Print();
    }
