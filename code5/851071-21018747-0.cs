    Public DataContext.Car MapCar(Car car)
    {
         Return new DataContext.Car
         {
             Id = car.Id,
             Make = car.Make,
             etc etc
         };
    }
    Public Car MapCar(DataContext.Car efCar)
    {
         Return new Car
         {
             Id = efCar.Id,
             Make = efCar.Make,
             etc etc
         };
    }
