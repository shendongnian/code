    public Car[] CreateAnyNumberOfCars(ICreateCars carType)
    {
        var result = new List<Car>();
        for (int i = new Random().Next(100); i >= 0; i--) {
            result.Add(carType.CreateCar("blue"));
        }
        return result.ToArray();
    }
