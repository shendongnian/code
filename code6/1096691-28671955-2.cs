    void pictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        Bitmap bmp = (Bitmap) pictureBox.Image;
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.DrawLine(Pens.Green, mDown, mCurrent);
         }
        mDown = PointF.Empty;
        mCurrent = PointF.Empty;
        pictureBox.Image = bmp;
    }
 
