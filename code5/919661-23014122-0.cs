    public class MyRenderer : ToolStripProfessionalRenderer {
      protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {    
        if (e.Item.GetType() == typeof(ToolStripDropDownButton)) {
          Rectangle r = e.ArrowRectangle;
          List<Point> points = new List<Point>();
          points.Add(new Point(r.Left - 2, r.Height / 2 - 3));
          points.Add(new Point(r.Right + 2, r.Height / 2 - 3));
          points.Add(new Point(r.Left + (r.Width / 2),
                               r.Height / 2 + 3));
          e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
          e.Graphics.FillPolygon(Brushes.Black, points.ToArray());
        } else {
          base.OnRenderArrow(e);
        }
      }
    }
