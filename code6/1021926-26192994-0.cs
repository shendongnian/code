    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using(Graphics g = Graphics.FromImage(bmp))
        {
            if (lineButton && mouseIsUp)
            {
                g.DrawLine(myPen, mAnchorPoint, mFinalPoint);
                mAnchorPoint = Point.Empty;
                mFinalPoint = Point.Empty;
            }
            //pictureBox1.Image = bmp;
        }
        e.Graphics.DrawImage(bmp, 0, 0);
    }
