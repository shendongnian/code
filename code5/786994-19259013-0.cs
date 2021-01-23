    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Location> locations = new List<Location>
            {
                new Location { Id = 1, ParentId = 1, Name = "TopLoc" },
                new Location { Id = 2, ParentId = 1, Name = "Loc1" },
                new Location { Id = 3, ParentId = 1, Name = "Loc2" },
                new Location { Id = 4, ParentId = 2, Name = "Loc1A" },
            };
            Dictionary<int, Location> dict = locations.ToDictionary(loc => loc.Id);
            foreach (Location loc in dict.Values)
            {
                if (loc.ParentId != loc.Id)
                {
                    Location parent = dict[loc.ParentId];
                    parent.Children.Add(loc);
                }
            }
            Location root = dict.Values.First(loc => loc.ParentId == loc.Id);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(root, settings);
            Console.WriteLine(json);
        }
    }
    class Location
    {
        public Location()
        {
            Children = new List<Location>();
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public List<Location> Children { get; set; }
    }
