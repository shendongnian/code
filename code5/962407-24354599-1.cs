    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
       Bitmap bmp = new Bitmap(pictureBox1.Image);
       Color colour = bmp.GetPixel(e.X, e.Y);
       label1.Text = colour.ToString();
       bmp.Dispose();
    }
