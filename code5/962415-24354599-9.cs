    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (pictureBox1.Image != null)
        {   // the 'real thing':
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color colour = bmp.GetPixel(e.X, e.Y);
            label1.Text = colour.ToString();
            bmp.Dispose();
        }
        else
        {   // just the background:
            Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            Color colour = bmp.GetPixel(e.X, e.Y);
            label1.Text = colour.ToString();
            bmp.Dispose();
        }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.DarkCyan, 0, 0, 99, 99);
        e.Graphics.FillRectangle(Brushes.DarkKhaki, 66, 55, 66, 66);
        e.Graphics.FillRectangle(Brushes.Wheat, 33, 44, 55, 66);
    }
