    // non-persistent test routine that will draw randomly in the picturebox
    private void cb_Test_Click(object sender, EventArgs e)
    {
        using (Graphics G = pictureBox1.CreateGraphics())
        {
            // set up the graphicsPath
            GraphicsPath path = new GraphicsPath();
            path.AddCurve(points.ToArray());
            // create the clipping region
            Region region = new Region(path);
            G.SetClip(region, CombineMode.Replace);
            // now we're good to go..
            // note: all drawing is done on the full range of the box!
            G.FillRectangle(Brushes.GhostWhite, pictureBox1.ClientRectangle);
            Random R = new Random();
            int xMax = pictureBox1.ClientSize.Width;
            int yMax = pictureBox1.ClientSize.Height;
            for (int i = 0; i < 1000; i++)
            {
                int x1 = R.Next(xMax);  int y1 = R.Next(yMax);
                int x2 = R.Next(xMax);  int y2 = R.Next(yMax);
                using (Pen pen = new Pen(Color.FromArgb(
                            255, x1 & 255, y1 & 255, x2 * y2 & 255), 10f))
                    G.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
