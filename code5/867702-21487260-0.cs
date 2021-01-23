    // Create the cars
    RaceCar rcar = new RaceCar();
    StandardCar scar = new StandardCar();
    // Add to the collection
    CarCollection col = new CarCollection();
    col.Add(rcar);
    col.Add(scar);
    // Iterate
    foreach(Car car in col.Collection)
    {
        if(car is RaceCar)
        {
            RaceCar racecar = (RaceCar)car;
        }
        else if(car is StandardCar)
        {
            StandardCar standCar = (StandardCar)car;
        }
        // ... etc
    }
