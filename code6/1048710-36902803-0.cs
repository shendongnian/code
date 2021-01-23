    public class VehicleIndex : AbstractMultiMapIndexCreationTask
    {
        public class Mapping
        {
            public string Price { get; set; }
            public string Color { get; set; }
            public string ReleaseDate { get; set; }
            public int?  EnginePower { get; set;}
        }
    
        public VehicleIndex()
        {
            this.AddMap<Car>(vehicle => from v in vehicle select new Mapping()
            {
                Price = v.Price,
                Color = v.Color,
                ReleaseDate = v.ReleaseDate,
                EnginePower = v.EnginePower
            });
            this.AddMap<Motorcycle>(vehicle => from v in vehicle select new Mapping()
            {
                Price = v.Price,
                Color = v.Color,
                ReleaseDate = v.ReleaseDate,
                EnginePower = v.EnginePower
            });
        }
    }
