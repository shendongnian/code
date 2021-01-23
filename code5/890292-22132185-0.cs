    public class Vehicle<TVehicleType> where TVehicleType: VehicleType {
    
        public TVehicleType Type { get; set; }
    }
    
    public class Car : Vehicle<CarType> {  }
    Car car = new Car();
    car.Type = new CarType();
