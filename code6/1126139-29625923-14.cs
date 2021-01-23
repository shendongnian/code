    struct Vector
        {
            public double Vx;
            public double Vy;
            public double Vz;
            public double R;
            public Vector(Point a,Point b)
            {
                R = a.Distance(b);
                Vx = (b.x - a.x)/R;
                Vy = (b.y - a.y)/R;
                Vz = (b.z - a.z)/R;
            }
    
        }
    public static Point GetPoint(Point a, Point b,double maxSegmentLength)
            {
                var Vab = new Vector(a, b);
                var dAC = Vab.R;
                while (dAC > maxSegmentLength) { dAC /= 2; } //or replace this lie with Math.Pow(0.5,(int)(-(Math.Log(maxSegmentLength / Vab.R) / Math.Log(2))) + 1)*Vab.R;
                return new Point() {
                    x = a.x + Vab.Vx * dAC ,
                    y = a.y + Vab.Vy * dAC ,
                    z = a.z + Vab.Vz * dAC 
                };
            }
