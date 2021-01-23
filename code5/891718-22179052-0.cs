    private void Display(Bitmap desktop) {
      if (desktop != null) {
        Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, 
                                pictureBox1.ClientSize.Height);
        using (Graphics g = Graphics.FromImage(bmp)) {
          g.DrawImage(desktop, Point.Empty);
        }
        dataGridView1.Rows.Add(bmp);
      }
    }
