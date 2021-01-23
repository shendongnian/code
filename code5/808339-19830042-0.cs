    public class Point : IEquatable<Point>
    {
        public Coordinate Coordinate { get; private set; }
    
        public override int GetHashCode()
        {
            return Coordinate.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Point);
        }
    
        public bool Equals(Point point)
        {
            if(point == null)
                return false;
    
            return this.Coordinate.Equals(point.Coordinate);
        }
    }
