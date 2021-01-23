    int original = 0;
    int resize = 0;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        original = pictureBox1.Width;
        resize = 1;
        timer.Interval = 10;
        timer1.Start();
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        resize = -1;
        timer1.Start();
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        timer1.Stop();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (resize > 0 && pictureBox1.Width < original + 10)
        {
            pictureBox1.Size = new Size(pictureBox1.Width + 2, pictureBox1.Height + 2);
            pictureBox1.Location = new Point(pictureBox1.Left - 1, pictureBox1.Top - 1);
        }
        else if (resize < 0 && pictureBox1.Width > original)
        {
            pictureBox1.Size = new Size(pictureBox1.Width - 2, pictureBox1.Height - 2);
            pictureBox1.Location = new Point(pictureBox1.Left + 1, pictureBox1.Top + 1);
        }
        else timer1.Stop();
    }
