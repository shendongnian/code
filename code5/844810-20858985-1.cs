    void tlp_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        int[] colWidths = tlp.GetColumnWidths();
        int[] rowHeights = tlp.GetRowHeights();
        int top = tlp.Parent.PointToScreen(tlp.Location).Y;
        for (int y = 0; y < rowHeights.Length; ++y) {
          int left = tlp.Parent.PointToScreen(tlp.Location).X;
          for (int x = 0; x < colWidths.Length; ++x) {
            if (new Rectangle(left, top, colWidths[x], rowHeights[y])
                              .Contains(MousePosition)) {
              Control c = tlp.GetControlFromPosition(x, y);
              if (c != null) {
                c.Dispose();
              }
            }
            left += colWidths[x];
          }
          top += rowHeights[y];
        }
      }
    }
