    class Program
    {
        static void Main(string[] args)
        {
            Mapper.CreateMap<LocationSource, LocationDestination>();
            Mapper.CreateMap<StoreSource, StoreDestination>();
            var storeSource = new StoreSource
            {
                Name = "Worst Buy",
                Locations = new EntityCollection<LocationSource> { new LocationSource { Id = 1, Address ="abc1"},new LocationSource { Id = 2, Address ="abc2"}}
            };
            var storeDestination = Mapper.Map<StoreSource, StoreDestination>(storeSource);
        }
    }
    
    public class StoreDestination
    {
        public string Name { get; set; }
        public IList<LocationDestination> Locations { get; set; }
    }
    public class LocationDestination
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
    public class StoreSource
    {
        public string Name { get; set; }
        public EntityCollection<LocationSource> Locations { get; set; }
    }
    public class LocationSource
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
