    GraphicsPath gp = new GraphicsPath();
    Point p;
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if(!label4.Visible) label4.Visible = true;
        label4.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
        if (panning) {
            if(p == Point.Empty) {
              p = e.Location;
              return;
            }
            gp.AddLine(p,e.Location);
            p = e.Location;
            pictureBox2.Invalidate();
        }
    }
    private void pictureBox2_Paint(object sender, PaintEventArgs e) {
       using(Pen p = new Pen(Color.Green,2f)){
            p.StartCap = p.EndCap = LineCap.Round;
            p.LineJoin = LineJoin.Round;
            e.Graphics.DrawPath(p,gp);
       }
    }
