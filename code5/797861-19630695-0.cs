    public static Entities.Car GetCar(int id)
    {
        using (var uow = new UnitOfWorkScope<CarsContext>(UnitOfWorkScopePurpose.Reading))
        {
            return uow.DbContext.Cars.Single(c => c.CarId == id);
        }
    }
