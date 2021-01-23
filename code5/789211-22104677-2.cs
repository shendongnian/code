    void scrollTimer_Tick(object sender, EventArgs e) {
      if (panel1.ClientRectangle.Contains(panel1.PointToClient(MousePosition))) {
        Point p = panel1.AutoScrollPosition;
        panel1.AutoScrollPosition = new Point(-p.X, -p.Y + scrollJump);
      } else {
        scrollTimer.Stop();
      }
    }
