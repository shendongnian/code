    // first check if the point is on a circle with the radius of the arc. 
    // Next check if it is between the start and end angles of the arc.
    public static void IsPointOnArc(Point p, Arc a)
    {
        if (p.Y * p.Y == a.Radius * a.Radius - p.X * p.X)
        {
            double t = Math.Acos(p.X / a.Radius);
            if (t >= a.StartAngle && t <= a.EndAngle)
            {
                Console.WriteLine("The point is on arc");
            }
        }
    }
