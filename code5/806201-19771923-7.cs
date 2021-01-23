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
            var filters = new[] {"Red", "Amazing" };
            var filteredOr = source
                   .AsQueryable()
                   .SearchTextFieldsOr(filters, t => t.Colour, t => t.Type)
                   .ToList();
            //2 records found because we're filtering on "Colour" or "Type"
            var filteredAnd = source
                   .AsQueryable()
                   .SearchTextFieldsAnd(filters, t => t.Colour, t => t.Type)
                   .ToList();
             //1 record found because we're filtering on "Colour" and "Type"
            
        }
    }
