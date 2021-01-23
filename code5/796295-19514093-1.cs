    public Point[] GetPoints(Rectangle container){
      Point[] points = new Point[6];
      int half = container.Width / 2;
      int quart = container.Width/4;
      points[0] = new Point(container.Left + quart, container.Top);
      points[1] = new Point(container.Right - quart, container.Top);
      points[2] = new Point(container.Right, container.Top + half);
      points[3] = new Point(container.Right - quart, container.Bottom);
      points[4] = new Point(container.Left + quart, container.Bottom);
      points[5] = new Point(container.Left, container.Top + half);
      return points;
    }
    private void Parent_Load(object sender, EventArgs e) {
      //This should be placed first
      // Make the button big enough to hold the whole region.
      btnExam.SetBounds( btnExam.Location.X, btnExam.Location.Y, 100, 100);
      // Make the GraphicsPath.
      GraphicsPath polygon_path = new GraphicsPath(FillMode.Winding);
      polygon_path.AddPolygon(GetPoints(btnExam.ClientRectangle));
      // Convert the GraphicsPath into a Region.
      Region polygon_region = new Region(polygon_path);
      // Constrain the button to the region.
      btnExam.Region = polygon_region;
    }
