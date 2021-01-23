    public class Point
    {
        private int _x;
        private int _y;
        private int _z;
        public Point(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }
        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }
        public int Z
        {
            get { return this._z; }
            set { this._z = value; }
        }
    }
