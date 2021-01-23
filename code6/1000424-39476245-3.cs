    [KnowTypes(typeof(Renault))]
    public class Vehicle
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
    }
    
    public class Car
    {
        public Vehicle Vehicle { get; set; }
        public string Matriculation { get; set; }
    }
    
