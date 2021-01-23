    public class Car
    {
        public int Id { get; set;}
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
    
    }
    public class ParkingGarage
    {
        private List<Car> parkedCars;
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }
    
        public List<Car> ParkedCars
        {
            get { return parkedCars; }
        }
        public ParkingGarage()
        {
            parkedCars = new List<Car>();
        }
    
        public void AddCar(Car car)
        {
            // perform validation
            parkedCars.Add(car);
        }
    }
