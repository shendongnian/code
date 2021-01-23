    public class Car : IVehicle
    {
    }
    ...
    public class CarRepository
    {
        ...
        public IVehicle LoadVehicle(int id)
        {
            var entity = // query DB for instance of DAL.Car
            return entity;
        }
    }
