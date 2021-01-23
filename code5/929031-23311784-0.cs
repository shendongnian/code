    public class Vehicle{
        public List<Wheel> Wheels {get; private set;}
        internal Vehicle(VehicleBuilder builder)
        {
             Wheels = builder.Wheels;
             //Set other useful properties...
        }
    }
    
    public class VehicleBuilder()
    {
        private List<Wheel> _wheels = new List<Wheel>;
        internal List<Wheel> Wheels
        {
          get{return _wheels;}
        }
        public void AddWheel(Wheel wheelToAdd)
        {
            _wheels.Add(wheelToAdd);
        }
       public Vehicle GetVehicle()
       {
          return new Vehicle(this);
       }
    }
