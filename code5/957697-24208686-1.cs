    int carid = 1;
    var corp = Corps.FirstOrDefault(corp => corp.Cars.Any(car => car.CarID == carid));
    if (Corp != null)
    {
        Console.WriteLine(Corp.CompanyName);
        Console.WriteLine(Corp.Cars.First(car => car.CarID == carid).CarName);
    }
    
