    [Theory]
    [ClassData(typeof(CarClassData))]
    public void CarTest(Car car)
    {
         var output = car;
         var result = _myRepository.BuyCar(car);
    }
