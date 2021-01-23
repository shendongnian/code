    public struct Length
    {
      private const double MetersPerYard = 0.9144;
      private double _meters;
      
      private Length(double meters)
      {
        _meters = meters;
      }
      
      public static Length FromMeters(double meters)
      {
        return new Length(meters);
      }
      
      public static Length FromYards(double yards)
      {
        return new Length(yards*MetersPerYard);
      }
      
      public double Meters 
      {
        get { return _meters; } 
      }
      
      public double Yards
      {
        get { return _meters / MetersPerYard; }
      }
    }
