    class Program
    {
        static void Main(string[] args)
        {
            // Set up some dummy data complete with reference loops
            Thing t1 = new Thing { Id = 1, Name = "Flim" };
            Thing t2 = new Thing { Id = 2, Name = "Flam" };
            Widget w1 = new Widget
            {
                Id = 5,
                Name = "Hammer",
                IsActive = true,
                Price = 13.99M,
                Created = new DateTime(2013, 12, 29, 8, 16, 3),
                Color = Color.Red,
            };
            w1.RelatedThings = new List<Thing> { t2 };
            t2.RelatedWidgets = new List<Widget> { w1 };
            Widget w2 = new Widget
            {
                Id = 6,
                Name = "Drill",
                IsActive = true,
                Price = 45.89M,
                Created = new DateTime(2014, 1, 22, 2, 29, 35),
                Color = Color.Blue,
            };
            w2.RelatedThings = new List<Thing> { t1 };
            t1.RelatedWidgets = new List<Widget> { w2 };
            // Here is the container class we wish to serialize
            PseudoContext pc = new PseudoContext
            {
                Things = new List<Thing> { t1, t2 },
                Widgets = new List<Widget> { w1, w2 }
            };
            // Serializer settings
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            // Do the serialization and output to the console
            string json = JsonConvert.SerializeObject(pc, settings);
            Console.WriteLine(json);
        }
        class PseudoContext
        {
            public List<Thing> Things { get; set; }
            public List<Widget> Widgets { get; set; }
        }
        class Thing
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Widget> RelatedWidgets { get; set; }
        }
        class Widget
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
            public decimal Price { get; set; }
            public DateTime Created { get; set; }
            public Color Color { get; set; }
            public List<Thing> RelatedThings { get; set; }
        }
        enum Color { Red, White, Blue }
    }
    
