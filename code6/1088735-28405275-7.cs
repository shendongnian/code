    pictureBox1.MouseDown += pictureBox1_MouseDown;
    pictureBox1.MouseMove += pictureBox1_MouseMove;
    pictureBox1.MouseUp   += pictureBox1_MouseUp;
    pictureBox1.Paint += pictureBox1_Paint;
    // class level
    Point mDown   = Point.Empty;
    Point mCurrent = Point.Empty;
    void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (mDown != Point.Empty) e.Graphics.DrawLine(Pens.White, mDown, mCurrent);
    }
    void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        mDown = Point.Empty;
    }
    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            mCurrent = e.Location;
            pictureBox1.Invalidate();
        }
    }
    void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = e.Location;
    }
