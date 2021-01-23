    public static Func<double,Point> MakeSimpleVelocityTrajectory(double xv, double yv, double x0, double y0)
    {
        return (t) => {
            return new Point(x0+xv*t,y0+yv*t);
        }
    }
