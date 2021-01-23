    public class Point2D {
      public int X, Y;
    }
    public class Point3D {
      public int X, Y, Z;
      public override Equals(object source) {
        var p2D = source as Point2D;
        if(p2D != null)
        {
          if(this.Z == 0 && p2D.X == this.X && p2D.Y == Y)
            return true;
          return false;
        }
        //...
      }
    }
