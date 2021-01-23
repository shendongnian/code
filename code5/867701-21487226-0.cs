    var collection = new CarCollection();
    collection.Collection= new List<Car>();
    collection.Collection.Add(new RaceCar());
    collection.Collection.Add(new StandardCar());
    foreach (var car in collection.Collection)
        Console.WriteLine(car.Name);
