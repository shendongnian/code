    void tlp_Paint(object sender, PaintEventArgs e) {
      int[] rowHeights = tlp.GetRowHeights();
      int[] colmWidths = tlp.GetColumnWidths();
      int boxLeft = 0;
      int boxTop = 0;
      int boxRight = 0;
      int boxBottom = 0;
      Rectangle r = Rectangle.Empty;
      for (int y = 0; y < rowHeights.Length; ++y) {
        boxLeft = 0;
        boxRight = 0;
        boxBottom += rowHeights[y];
        for (int x = 0; x < colmWidths.Length; ++x) {
          boxRight += colmWidths[x];
          if (x == 1 && y == 3) {
            r.X = boxLeft;
            r.Y = boxTop;
          }
          if (x == 2 && y == 5) {
            r.Width = boxRight - r.Left;
            r.Height = boxBottom - r.Top;
          }
          boxLeft += colmWidths[x];
        }
        boxTop += rowHeights[y];
      }
      if (!r.IsEmpty) {
        e.Graphics.TranslateTransform(tlp.AutoScrollPosition.X,
                                      tlp.AutoScrollPosition.Y);
        using (var br = new LinearGradientBrush(
                              r,
                              Color.Red,
                              Color.Black,
                              LinearGradientMode.ForwardDiagonal)) {
          e.Graphics.FillRectangle(br, r);
        }
      }
    }
