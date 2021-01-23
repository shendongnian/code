    public class Vehicle
    {
        public Vehicle()
        {
            this.Cars = new List<Car>();
        }
    
        public int Id {get;set;}
        public string Type {get;set;}
        public string CreatedBy {get;set;}
        public List<Car> Cars {get;set;}
    }
    
    public class Car
    {
        public int Id {get;set;}
        public bool SomeBool {get;set;}
        public Vehicle Vehicle {get;set;}
    }
