    public Vehicle AddVehicle(VehicleModel vehicle, IEnumerable<Car> cars)
    {
        using(var context = this.ClientRepositories.DBContext)
        {
            context.Vehicles.Add(new Vehicle()
            {
            Type = vehicle.VehicleType,
            CreatedBy = vehicle.CreatedBy
            };
    
        foreach(var c in cars)
        {
            context.Cars.Add(new Car()
            {
                SomeBool = false,
                Vehicle = vehicle
            };
        }
      
        context.SaveChanges()
        }
    }
