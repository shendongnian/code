    public void DrawRectangle(Rectangle rectangle)
    {
       Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
       using (Graphics g = Graphics.FromImage(bmp))
       {
          g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
          g.FillEllipse(new SolidBrush(Color.Red), rectangle);
       }
       pictureBox1.Image = bmp;
    }
