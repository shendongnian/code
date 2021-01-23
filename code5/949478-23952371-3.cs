        public class MenuRoot
        {
            public List<Menu> Category { get; set; }
        }
    
        public class Menu
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Menu> SubItems { get; set; }
        }
