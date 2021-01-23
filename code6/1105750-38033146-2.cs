    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
    	this.pictureBox1.Location = new Point(e.X + 5, e.Y - 5);
        int segment = (int)GetAngle(new Rectangle(0, 0, 400, 400), e.Location);
    	this.pictureBox1.BackColor = Color.FromArgb(255, Rescale(segment), 0, 0);
    }
