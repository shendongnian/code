     public struct Line
     {
         public List<Point> Points { get; private set; }
         public double MaxX { get; private set; }
         public double MinX { get; private set; }
         public double MinY { get; private set; }
         public double MaxY { get; private set; }
    
         public Line(Point start, Point end) : this()
         {
             Points = new List<Point>();
             Points.AddRange(new[] {start, end});
             var xs = Points.Select(p => p.X);
             var ys = Points.Select(p => p.Y);
             MaxX = xs.Max();
             MinX = xs.Min();
             MaxY = ys.Max();
             MinY = ys.Min();
         }
     }
