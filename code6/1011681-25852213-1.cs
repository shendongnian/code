    void savePictureBox(PictureBox PB, string fileName)
    {
        using (Bitmap bmp = new Bitmap(PB.ClientSize.Width, PB.ClientSize.Height))
        {
            PB.DrawToBitmap(bmp, PB.ClientRectangle);
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
