    enum CartesianQuadrant {
      I,
      II,
      III,
      IV,
      None,
    }
    struct Point {
      public readonly double X;
      public readonly double Y;
      public readonly CartesianQuadrant Quadrant;
      public Point(double x, double y) : this() {
          X = x; 
          Y = y; 
          Quadrant = x == 0 || y == 0 ? CartesianQuadrant.None :
                     x > 0 ? y > 0 ? CartesianQuadrant.I : CartesianQuadrant.IV :
                     y > 0 ? CartesianQuadrant.II : CartesianQuadrant.III;
      }
    }
