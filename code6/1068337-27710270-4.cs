    IntPtr memDc, hBmp, hOldBmp;
    private void Form1_Load(object sender, EventArgs e)
    {
        APIHelp.BLENDFUNCTION blend;
        //Only works with a 32bpp bitmap
        blend.BlendOp = APIHelp.AC_SRC_OVER;
        //Always 0
        blend.BlendFlags = 0;
        //Set to 255 for per-pixel alpha values
        blend.SourceConstantAlpha = 255;
        //Only works when the bitmap contains an alpha channel
        blend.AlphaFormat = APIHelp.AC_SRC_ALPHA;
        IntPtr screenDc;
        screenDc = APIHelp.GetDC(IntPtr.Zero);
            
        Bitmap bmp;
        using (bmp = (Bitmap)Bitmap.FromFile(@"C:\.......png")) //the image must be the same size as your form
        {
            memDc = APIHelp.CreateCompatibleDC(screenDc);
            hBmp = bmp.GetHbitmap(Color.FromArgb(0));
            hOldBmp = APIHelp.SelectObject(memDc, hBmp); //memDc is a device context that contains our image
        }
        APIHelp.DeleteDC(screenDc);
        APIHelp.Size newSize;
        APIHelp.Point newLocation;
        APIHelp.Point sourceLocation;
        newLocation.x = this.Location.X;
        newLocation.y = this.Location.Y;
        sourceLocation.x = 0;
        sourceLocation.y = 0;
        newSize.cx = this.Width;
        newSize.cy = this.Height;
        APIHelp.UpdateLayeredWindow(Handle, IntPtr.Zero, ref newLocation, ref newSize, memDc, ref sourceLocation, 
               0, ref blend, APIHelp.ULW_ALPHA);
    }
