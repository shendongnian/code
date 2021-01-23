    internal struct Point
    {
        internal int X { get; private set; }
        internal int Y { get; private set; }
        internal Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        internal Point NewX(int deltaX)
        {
            return new Point(X + deltaX, Y);
        }
        internal Point NewY(int deltaY)
        {
            return new Point(X, Y + deltaY);
        }
    }
