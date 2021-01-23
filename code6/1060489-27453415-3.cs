    public interface IPoint
    {
        int X { get; set; }
        int Y { get; set; }
    }
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class GazePoint : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GazePoint()
        {
        }
        public GazePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
