    class MyCar : IVehicle
    {
       private Car _car;
       public MyCar (Car car){ _car = car }
       int Id; // returns _car.CarId
       string Name; // returns _car.CarName
    }
    class MyMotorcycle : IVehicle
    {
       private Motorcycle _moto;
       public MyCar (Motorcycle moto){ _moto = moto; }
       int Id; // returns _moto.MotoId
       string Name; // returns _moto.MotoName
    }
