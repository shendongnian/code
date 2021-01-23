    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    
    
        public static bool operator == (Point p1,Point p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (ReferenceEquals(p1, null)) return false;
            return p1.Equals(p2);
        }
    
        public static bool operator != (Point p1, Point p2)
        {
            return !(p1 == p2);
        }
    
        public bool Equals(Point other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return (this.X == other.X && this.Y == other.Y);
        }
    
        public override bool Equals(object obj)
        {
            Point other = obj as Point;
            if (ReferenceEquals(other, null))
                return false;
            return Equals(other);
        }
    }
