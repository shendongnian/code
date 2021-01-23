    static bool HasBadData( double[,] doubles )
    {
      bool hasBadData = doubles.Cast<double>()
                               .Any( x => double.IsInfinity(x) || double.IsNaN(x) )
                               ;
      return hasBadData ;
    }
