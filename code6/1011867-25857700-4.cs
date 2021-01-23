    void saveControl(Control Ctl, string fileName)
    {
        Rectangle Rect = Ctl.ClientRectangle;
        // if (Ctl is Form) Rect = Ctl.Bounds; // (*)
        using (Bitmap bmp = new Bitmap(Rect.Width, Rect.Height))
        {
            Ctl.DrawToBitmap(bmp, Rect );
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
