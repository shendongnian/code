    Size originalSize;   //**
    Point originalLoc;   //**
    int resize = 0;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        originalSize = pictureBox1.Size;   //**
        originalLoc= pictureBox1.Location;
        resize = 1;
        timer1.Interval = 10;
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
        pictureBox1.Size = originalSize;
        pictureBox1.Location = originalLoc;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (resize > 0 && pictureBox1.Width < originalSize.Width+ 10)     //**
        {
            pictureBox1.Size = new Size(pictureBox1.Width + 2, pictureBox1.Height + 2);
            pictureBox1.Location = new Point(pictureBox1.Left - 1, pictureBox1.Top - 1);
        }
        else if (resize < 0 && pictureBox1.Width > originalSize.Width)    //**
        {
            pictureBox1.Size = new Size(pictureBox1.Width - 2, pictureBox1.Height - 2);
            pictureBox1.Location = new Point(pictureBox1.Left + 1, pictureBox1.Top + 1);
        }
        else timer1.Stop();
    }
