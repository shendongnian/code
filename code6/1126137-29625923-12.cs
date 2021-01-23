    struct Point
    {
        public double x;
        public double y;
        public double z;
        public double Distance(Point b)
        {
            return Math.Sqrt(Math.Pow(b.x - this.x, 2) +
                             Math.Pow(b.y - this.y, 2) +
                             Math.Pow(b.z - this.z, 2));
        }
        public  Point MidPoint(Point b)
        {
            return new Point()
            {
                x = (this.x + b.x) / 2,
                y = (this.y + b.y) / 2,
                z = (this.z + b.z) / 2
            };
        }
    }
