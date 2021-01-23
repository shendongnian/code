    using (Font font = new Font("Arial", 80, FontStyle.Bold))
    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
    {
	    float w = pictureBox1.Image.Width / 2f;
	    float h = pictureBox1.Image.Height / 2f;
	    g.TranslateTransform(w, h);
        g.RotateTransform(90);
        SizeF size = g.MeasureString("Hello world", font);
        PointF drawPoint = new PointF(-size.Width / 2f, -size.Height / 2f);
        g.DrawString("Hello world", font, Brushes.White, drawPoint);
    }
    pictureBox1.Refresh();
