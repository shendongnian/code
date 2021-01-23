    void panel1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        using (Graphics g = Graphics.FromImage(bmp)) {
          g.FillEllipse(Brushes.Red, new Rectangle(e.X - 4, e.Y - 4, 8, 8));
        }
        panel1.Invalidate();
      }
    }
