    public bool Process( IEnumerable<Car> cars , Action<Car> process )
    {
      bool success = false ;
      foreach( Car car in cars )
      {
        if ( car.IsEmpty )
        {
          process(car) ;
          success = true ;
          break ;
        }
        car.EmptyOut() ;
      }
      return success ;
    }
