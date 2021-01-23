    private int pos = 0; //x coordinate of mouse in picturebox
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if(pos == 0)
        {
            e.Graphics.DrawImage(Properties.Resources.imageRight, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
        }
        else
        {
            e.Graphics.DrawImage(Properties.Resources.imageLeft, new Rectangle(0, 0, pos, pictureBox1.Height),
                new Rectangle(0, 0, pos, pictureBox1.Height), GraphicsUnit.Pixel);
            e.Graphics.DrawImage(Properties.Resources.imageRight, new Rectangle(pos, 0, pictureBox1.Width - pos, pictureBox1.Height),
                new Rectangle(pos, 0, pictureBox1.Width - pos, pictureBox1.Height), GraphicsUnit.Pixel);
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pos = e.X;
        pictureBox1.Invalidate();
    }
