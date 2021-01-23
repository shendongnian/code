    class BoxEqualityComparer : IEqualityComparer<MCvBox2D>
    {
        private static Double Delta = 0.01; //set your tolerance here
        public bool Equals(MCvBox2D b1, MCvBox2D b2)
        {
            if (CentersAreCloseEnough(b1.Center, b2.Center))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private CentersAreCloseEnough(PointF c1, PointF c2)
        {
            return Math.Abs(c1.X - c2.X) < Delta && Math.Abs(c1.Y - c2.Y) < Delta;
        }
    }
