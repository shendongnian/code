    Bitmap capture;
    private void timer1_Tick(object sender, EventArgs e)
    {
        // The screenshot will be stored in this bitmap.
        capture = new Bitmap(screenBounds.Width, screenBounds.Height);
        // The code below takes the screenshot and
        // saves it in "capture" bitmap.
        g = Graphics.FromImage(capture);
        g.CopyFromScreen(Point.Empty, Point.Empty, screenBounds);
        // This code assigns the screenshot
        // to the Picturebox so that we can view it
        pictureBox1.Image = capture;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (paint)
        {
            using (Graphics g = Graphics.FromImage(capture))
            {
                color = new SolidBrush(Color.Black);
                g.FillEllipse(color, e.X, e.Y, 5, 5);
            }
        }
    }
