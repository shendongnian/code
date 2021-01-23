    public class engine
    {
        public int id { get; set; }
        // other things...
    }
    public class maintenance
    {
        public int id { get; set; }
        // other things...
    }
    public class Vehicle
    {
        public int id { get; set; } // vehicle_id
        public engine engine { get; set; }
        public maintenance maint { get; set; }
    }
