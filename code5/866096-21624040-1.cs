    public abstract class DomainEntity
    {
        // Set UniqueId to protected, so you can access it from childs
        protected int? UniqueId;
    }
    
    public class City : DomainEntity
    {
        public string Name { get; private set; }
        public City(string name)
        {
            Name = name;
        }
        
        // Introduce a factory that creates a domain entity from a table entity
        // make it internal, so you can access only from defined assemblies 
        // also if you don;t like static you can introduce a factory class here
        // just put it inside City class definition
        internal static City CreateFrom(CityTbl cityTbl)
        {
            var city = new City(cityTbl.Name);
            // set the id field here
            city.UniqueId = cityTbl.Id;
            return city;
        }
    }
    
    public class CityTbl
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    static void Main()
    {
        var city = new City("Minsk");
        // can't access UniqueId and factory from a different assembly
        // city.UniqueId = 1;
        // City.CreateFrom(new CityTbl());
    }
    // Your repository will look like
    // and it won't know about how to create a domain entity which is good in terms of SRP
    // You can inject the factory through constructor if you don't like statics
    // just put it inside City class
    public class CityRepository : ICityRepository
    {
        public City Find(int id)
        {
            var cityTblEntity = context.Set<CityTbl>().Find(id);
            return City.CreateFrom(cityTblEntity);
        }
    }
