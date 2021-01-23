    public class Line
    {
        public Line(double startX, double startY, double endX, double endY)
            : this(new Point(startX, startY), new Point(endX, endY))
        {
        }
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Point Start { get; private set; }
        public Point End { get; private set; }
    }
