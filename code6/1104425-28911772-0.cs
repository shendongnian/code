    public interface ICarbonFootprint
    {
        int GetCarbonFootprint();
    }
    public class Building : ICarbonFootprint
    {
        public int BuildingSquareFootage { get; set; }
        public string Address { get; set; }
        public Building(int buildingSquareFootage, string address)
        {
            BuildingSquareFootage = buildingSquareFootage;
            Address = address;
        }
        public int GetCarbonFootprint()
        {
            return BuildingSquareFootage * 50;
        }
        public override string ToString()
        {
            return string.Format("Building");
        }
    }
    public abstract class CarBicycleBase : ICarbonFootprint
    {
        public string Make { get; set; }
        public string Model { get; set; }
        protected CarBicycleBase(string make, string model)
        {
            Make = make;
            Model = model;
        }
        public abstract int GetCarbonFootprint();
    }
    public class Bicycle : CarBicycleBase
    {
        public Bicycle(string make, string model)
            : base(make, model) { }
        public override int GetCarbonFootprint()
        {
            return 0;
        }
        public override string ToString()
        {
            return string.Format("Bike");
        }
    }
    public class Car : CarBicycleBase
    {
        public int GallonOfGas { get; set; }
        public Car(int gallonOfGas, string make, string model)
            : base(make, model)
        {
            GallonOfGas = gallonOfGas;
        }
        public override int GetCarbonFootprint()
        {
            return GallonOfGas * 20;
        }
        public override string ToString()
        {
            return string.Format("Car");
        }
    }
