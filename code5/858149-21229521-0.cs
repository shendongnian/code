    public class Driver
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Vehicle Vehicle  { get; set; }
    }
    
    public class Vehicle
    {  
        public int Id { get; set; }
        public String Name { get; set; }
    
        public virtual Driver Driver { get; set; }
    
        public int VehicleGroupId { get; set; }
        public virtual VehicleGroup Vehicles { get; set; }
    }
