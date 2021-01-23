    e.PaintBackground(e.ClipBounds, true);
    e.PaintContent(e.ClipBounds);
    using (Pen p = new Pen(Brushes.Black, 12)) {
      e.Graphics.DrawLine(p, new Point(e.CellBounds.Left, e.CellBounds.Bottom),
                             new Point(e.CellBounds.Right, e.CellBounds.Bottom));
    }
    using (Pen p = new Pen(Brushes.Black, 6)) {
      e.Graphics.DrawLine(p, new Point(e.CellBounds.Right, e.CellBounds.Top),
                             new Point(e.CellBounds.Right, e.CellBounds.Bottom));
    }
    e.Handled = true;
