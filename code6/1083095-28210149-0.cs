    private void button1_Click(object sender, EventArgs e)
    {
       Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
       Size yourGridspacing = new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
       using (Graphics G = Graphics.FromImage(bmp))
       {
          ControlPaint.DrawGrid(G, new Rectangle(Point.Empty, bmp.Size), 
                                   yourGridspacing , Color.Black);
       }
       // now you can save it..
       bmp.Save("yourPngFileName, ImageFormat.Png);
       // ..or insert it as the Image..
       pictureBox1.Image = bmp;
       // ..or as the Background Image:
       pictureBox1.BackgroundImage = bmp;
    }
