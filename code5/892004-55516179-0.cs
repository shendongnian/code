    class Car
    {
    }
    class Truck : Car
    {
    }
    interface IDriver
    {
        Car Vehicle { get; }
    }
    class Driver : IDriver
    {
        public Car Vehicle { get; }
        public Driver(Car vehicle)
        {
            Vehicle = vehicle;
        }
    }
    interface ITrucker : IDriver
    {
        new Truck Vehicle { get; }
    }
    class Trucker : Driver, ITrucker
    {
        public new Truck Vehicle
        {
            get { return (Truck) base.Vehicle; }
        }
        public Trucker(Truck vehicle)
            : base(vehicle)
        {
        }
    }
