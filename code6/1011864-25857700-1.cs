    void saveControl(Control Ctl, string fileName)
    {
        Rectangle Rect = Ctl.ClientRectangle;
        // if (Ctl is Form) Rect = Ctl.Bounds; // (*)
        using (Bitmap bmp = new Bitmap(Ctl.ClientSize.Width, Ctl.ClientSize.Height))
        {
            Ctl.DrawToBitmap(bmp, Ctl.ClientRectangle);
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
