        List<Point> points = new List<Point>();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left)
       {
          points.Add(e.Location);
 
          pictureBox1.Invalidate();
           dataGridView1.DataSource = null;
            dataGridView1.DataSource = points;
        }
        }
 
           private void pictureBox1_Paint(object sender, PaintEventArgs e)
       {
           if (points.Count > 1)
            e.Graphics.DrawPolygon(Pens.DarkBlue, points.ToArray());
 
           foreach (Point p in points)
          {
            e.Graphics.FillEllipse(Brushes.Red,
            new Rectangle(p.X - 2, p.Y - 2, 4, 4));
          }
          }
