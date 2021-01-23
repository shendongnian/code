    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; private set; }
        public double Y { get; private set; }
        public override bool Equals(object obj)
        {
            Point other = obj as Point;
            if (other == null)
                return false;
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {            
            return X.GetHashCode() * 19 + Y.GetHashCode();
        }
    }
