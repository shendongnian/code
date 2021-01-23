     public static bool equals(Point p1, Point p2)
     {
         if (object.ReferenceEquals(p1, p2))
             return true;
         if (object.ReferenceEquals(p1, null) || object.ReferenceEquals(p2, null))
             return false;
         return p1.X == p2.X && p1.Y == p2.Y;
     }
