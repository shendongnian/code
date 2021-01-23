    public Line GetHotSpottedLine(Point mousePos){
            var line = lines.Where(line =>
            {
                Point p1 = new Point(Math.Min(line.P1.X, line.P2.X), Math.Min(line.P1.Y, line.P2.Y));
                Point p2 = new Point(Math.Max(line.P1.X, line.P2.X), Math.Max(line.P1.Y, line.P2.Y));
                return mousePos.X >= p1.X && mousePos.X <= p2.X && mousePos.Y >= p1.Y && mousePos.Y <= p2.Y;
            }).FirstOrDefault(line => {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddLine(line.P1, line.P2);
                    //You can declare your pen outside and this pen should be used to draw your lines.
                    using (Pen p = new Pen(Color.Red, 20))
                    {
                        return gp.IsOutlineVisible(mousePos, p);
                    }
                }
            });
            return line;
     }
     public class Line{
            public Point P1 { get; set; }
            public Point P2 { get; set; }
     }
     List<Line> lines = new List<Line>();
