    public class Car : IVehicle
    {
    }
    ...
    public class CarService
    {
        public IVehicle FindCarById(int id)
        {
            var repo = new DAL.CarRepository(...);
            var carEntity = repo.LoadVehicle(id); // returns DAL.Car instance 
            return new BLL.Car // we turn DAL.Car into our DLL.Car
            {
                Color = carEntity.Color,
                Speed = carEntity.Speed
            };
        }
    }
