    private void chart_PostPaint(object sender, ChartPaintEventArgs e)
    {
      ChartArea a = sender as ChartArea;
      if (a != null)
      {
        Gaphics g = e.ChartGrpahics.Graphics;
        RectangleF r = e.ChartGraphics.GetAbsoluteRectangle(new RectangleF(0,0,10,50)); // the rect you need
        g.FillRectangle(new Brushes.Yellow, r);
      }
    }
