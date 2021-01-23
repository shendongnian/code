    public interface IVehicleRepository : IRepository<Vehicle>{
        IEnumerable<int> GetDistinctVehicle();
    }
    
    public VehicleRepository : EfRepository<Vehicle>, IVehicleRepository{
        
        public VehicleRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<int> GetDistinctVehicle(){
            Context.Set<Vehicle>().Select(x=> x.ModelYear).Distinct();
        }
    }
