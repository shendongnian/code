    public class Vehicle
    {
    }
    public interface IRepository
    {
        IList<Vehicle> Vehicles { get; set; }
    }
    public class Repository : IRepository
    {
        private EntitySet<Vehicle> _Vehicles;
        public IList<Vehicle> Vehicles
        {
            get
            {
                return this._Vehicles;
            }
            set
            {
                this._Vehicles.Assign(value);
            }
        }
    }
