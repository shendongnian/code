        class Point
        {      
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        class PointM : Point
        {
            public double M { set; get; }  
            public PointM(double x, double y, double m) : base(x,y)
            {
                M = m;
            }
        }
