    private void drawPoints() {
      SuspendLayout();
    
      try {
        using (Graphics g = CreateGraphics()) {
          int i = 0; 
          int radius = 15;
    
          using (b = new SolidBrush(Color.Red)) {
            foreach (Point Pointaktuell in PointList) {
              g.FillEllipse(b, (int)(Pointaktuell.X - radius / 2.0), (int)(Pointaktuell.Y - radius / 2.0), radius, radius);
              i += 1;
            }
          }
        }
      }
      finally {
        ResumeLayout();
      }
    }
