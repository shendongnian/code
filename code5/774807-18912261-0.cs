        class cPoint
        {
            private readonly double[] values = new double[4];
            public double this[int index] {
                get { return values[index]; }
                set { values[index] = value; }
            }
            public int Length
            {
                get { return values.Length; }
            }
            public double a
            {
                get { return this[0]; }
                set { this[0] = value; }
            }
            public double b
            {
                get { return this[1]; }
                set { this[1] = value; }
            }
            public double c
            {
                get { return this[2]; }
                set { this[2] = value; }
            }
            public double d
            {
                get { return this[3]; }
                set { this[3] = value; }
            }
        };
