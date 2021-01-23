     private void Button2_Paint(object sender, PaintEventArgs e)
     {
        Button btn= (Button)sender;
        Graphics g = e.Graphics;
        g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(PointF.Empty, new PointF(button2.Width, button2.Height), Color.Pink, Color.Red), new RectangleF(PointF.Empty, button2.Size));
        SizeF size = g.MeasureString(btn.Text, btn.Font);
        PointF topLeft = new PointF(btn.Width / 2 - size.Width / 2, btn.Height / 2 - size.Height / 2);
        g.DrawString(btn.Text, btn.Font, Brushes.Black, topLeft);
      }
