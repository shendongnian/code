    var toys = new List<Toy>
    {
        new Car {Color = Color.Red, Manufacturer = "HotWheels"},
        new Elephant {TrunkLength = 36, Manufacturer = "Steiff Harlequin"}
    };
    foreach (var toy in toys)
    {
        var car = toy as Car;
        if (car != null)
        {
            // Set properties or call methods on the car here
            car.Color = Color.Blue;
            // Continue the loop
            continue;
        }
        var elephant = toy as Elephant;
        if (elephant != null)
        {
            // Do something with the elephant object
            elephant.TrunkLength = 48;
            
            // Continue the loop
            continue;
        }
    }
