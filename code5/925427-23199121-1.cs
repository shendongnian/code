    public void DoSomeStuffWithCars(List<Car> cars)
    {
          foreach(Car c in cars)
          {
              Hatchback h = c as Hatchback.
              if(h != null)  // alternatively you can use the 'is' operator
              {
                   string hatchDetails = h.GetHatchbackDetails();
                   // do some hatchback stuff
              } 
              // logic here applies to all cars
          }
    }
