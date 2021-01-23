    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuSection> Sections { get; set; }
        
    }
    
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SectionItem> Items { get; set; }
    }
    
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    } 
