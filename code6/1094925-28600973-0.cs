    public interface IVehicle
    {
        int NumberOfSeats { get; }
        string Brand { get; set; }
    }
    public class Car : IVehicle
    {
        public int NumberOfSeats { get; private set; }
        public string Brand { get; set; }
        public Car(int noofseats, string brand)
        {
            this.NumberOfSeats = noofseats;
            this.Brand = brand;
        }
    }
    Car bmw = new Car(4, "BMW");
    Car toyota = new Car(4, "Toyota");
    Car qashqai = new Var(7, "Nissan");
