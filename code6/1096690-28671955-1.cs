    void pictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.None) return;
        PointF e_ = unZoomed(e.Location);
        mCurrent = e_;
        pictureBox.Invalidate();
    }
