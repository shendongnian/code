    abstract class Vehicle
    {
        protected string _type;
        public int Wheels { get; set; }
        public Vehicle(string type)
        {
            this._type = type;
        }
    }
    class Bike : Vehicle
    {
        public Vehicle()
        : base("Bike")
        {
            // no implementation
        }
    }
    class Car : Vehicle
    {
        public int Doors { get; set; }
        public Vehicle()
        : base("Car")
        {
            // no implementation
        }
    }
