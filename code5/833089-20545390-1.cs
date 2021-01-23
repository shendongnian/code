    public interface ITransport { bool Driveable();}
    public interface IDriveableStrategy { bool IsDriveable(ITransport transport);}
    public class Car : ITransport
    {
        private IDriveableStrategy Strategy { get; set; }
        public bool Driveable()
        {
            return Strategy.IsDriveable(this);
        }
    }
    public class Motorcycle : ITransport
    {
        private IDriveableStrategy Strategy { get; set; }
        public int NumWheels { get; set; }
        public string WeatherExceptions { get; set; }
        public Motorcycle(IDriveableStrategy driveableStrategy, int numWheels, string weatherExceptions)
        {
            Strategy = driveableStrategy;
            NumWheels = numWheels;
            WeatherExceptions = weatherExceptions;
        }
        public bool Driveable()
        {
            return Strategy.IsDriveable(this);
        }
    }
    public class MotorcycleDriveableStrategy : IDriveableStrategy
    {
        //What i would like to do
        public bool IsDriveable(ITransport transport)
        {
            var mc = transport as Motorcycle;
            if (mc == null) return false;
            return mc.NumWheels > 2;
        }
    }
    // And for the Car strategy
    public class CarDriveableStrategy : IDriveableStrategy
    {
        //place ur implementation here ...
        public bool IsDriveable(ITransport transport) {return true;}
    }
    public class TestMotorcycle
    {
        public TestMotorcycle()
        {
            var mcs = new MotorcycleDriveableStrategy();
            var mc = new Motorcycle(mcs, 2, "abc");
            Console.WriteLine("Motorcycle is {0}drivable", mc.Driveable()?"":"not ");
        }
    }
