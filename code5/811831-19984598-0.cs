    struct Point : IEquatable<Point> {
      public int X,Y;
      public Point(int x, int y) { X=x; Y=y; }
      public bool Equals(Point other) { return other.X==X && other.Y==Y; }
      public override bool Equals(Object obj) { return (obj is Point) && Equals((Point)Obj);
      public int GetHashCode() { return X*47 + Y; }
    }
    class MovableEntity 
    {
      public Point Location;
      ExposedHolder(Point v) { Location = v; }
    }
