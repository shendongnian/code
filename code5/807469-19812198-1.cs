        public struct Vector
        {
            ....
            public Vector WithX(double x)
            {
                return new Vector(x, this.y, this.z);
            }
