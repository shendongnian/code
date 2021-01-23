    public enum Category
    {
        Food,
        Sports,
        Entertainment,
        Commuity,
        Work
    }
    
    public class Product
    {
        public string Name { get; set; }
        public Category ProductCategory { get; set; }
        public string Brand { get; set; }
    }
