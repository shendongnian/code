    public void DoSomeStuffWithCars(List<Car> cars)
    {
          foreach(Car c in cars)
          {
              Hatchback h = c as Hatchback.
              if(h != null)  // alternatively you can use the 'is' operator
              {
                   // do some hatchback stuff with h.HatchbackInfo
              } 
              // logic here applies to all cars
          }
    }
