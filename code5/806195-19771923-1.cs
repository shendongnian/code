    public class Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var source = new[]{
                new Entity { Colour = "Red", Model = "New", Name="Super", Type="Filter"},
                new Entity { Colour = "Green", Model = "New", Name="Super", Type="Filter"},
                new Entity { Colour = "Green", Model = "New", Name="Super", Type="Filter"},
                new Entity { Colour = "Green", Model = "New", Name="Super", Type="Filter"},
                new Entity { Colour = "Green", Model = "New", Name="Super", Type="Filter"},
                new Entity { Colour = "Green", Model = "New", Name="Super", Type="Amazing"},
            };
            var filters = new[] {"Red", "Amazing", "New", "Super"};
            var filtered = source.AsQueryable()
                   .SearchTextFields(filters, t => t.Colour, t => t.Type)
                   .ToList();
            //2 records found because we're only filtering on "Colour" and "Type"
        }
    }
