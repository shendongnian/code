    private void pictureBox1_MouseHover(object sender, EventArgs e)
    {
      Point p = pictureBox1.PointToClient(Cursor.Position);
      string msg = String.Format("row {0}  column {1}", p.Y , p.X );
      toolTip1.SetToolTip(pictureBox1, msg);
    }
