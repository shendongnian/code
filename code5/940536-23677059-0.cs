    class Point : IEqualityComparer<Point>
    {
        private int _x;
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        private int _y;
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
        public bool Equals(Point p1, Point p2)
        {
            // Returns true if both points have the same x and y values
            // Returns false otherwise.
            if (p1 == null || p2 == null)
               return false;
            return (p1.x == p2.x) && (p1.y == p2.y);
        }
        public int GetHashCode(Point obj)
        {
            return obj.x ^ obj.y;
        }
    }
