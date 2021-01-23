    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle rect = new Rectangle(10, 10, 100, 100);
        e.Graphics.FillEllipse(Brushes.Green, rect);
        using (Pen pen = new Pen(Colors.Red, 2f))
        {
          e.Graphics.DrawEllipse(pen , rect);
        }
    }
