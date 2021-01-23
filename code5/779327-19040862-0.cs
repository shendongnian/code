    {
       using(var context = new MyContext())
       {
          // Doing this the wheel collection WON'T GET LOADED
          var cars = context.Cars;
       }
       using(var context = new MyContext())
       {
          // Doing this the wheel collection WILL get loaded
          var cars = context.Cars.Include(_c => _c.Wheels);
       }
       using(var context = new MyContext())
       {
          // Doing this also gets the wheel collection loaded
          // But this time, it will retrieve wheel-by-wheel on each loop.
          var cars = context.Cars;
          foreach(var car in cars)
          {
             foreach(var wheel in wheels)
             { /* do something */ }
          }
       }
       using (var context = new MyContext())
       {
          // Doing this will get your id's without loading the entire wheel collection
          var cars = context.Cars;
          var wheelsIDs = cars.Wheels.Select(_w => _w.Id).ToList();
       }
       using (var context = new MyContext())
       {
          // Doing this will return every wheel for your car.
          // This improves performance over the other that retrieves wheel-by-wheel.
          var cars = context.Cars;
          foreach(var car in cars)
          {
             var wheels = car.Wheels.ToList();
          }
       }
    }
