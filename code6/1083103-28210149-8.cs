    void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
       Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
       Size yourGridspacing = new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
       using (Graphics G = pictureBox1.CreateGraphics())
             ControlPaint.DrawGrid(G, new Rectangle(Point.Empty, bmp.Size), 
                                      yourGridspacing , Color.Black);
    }
