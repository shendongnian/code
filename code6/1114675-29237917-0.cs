    struct FunctionPoint : IComparable<FunctionPoint>
    {
        public double X, Y;
        public FunctionPoint(double x)
        {
            this.X = x;
            this.Y = 0;
        }
        public FunctionPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public int CompareTo(FunctionPoint other)
        {
            return X.CompareTo(other.X);
        }
    }
