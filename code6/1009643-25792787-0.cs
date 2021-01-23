    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
    }
    public class ProductDto : Product
    {
        public ICollection<int> ProductTypeIds { get; set; }
        public ICollection<string> ProductTypeNames { get; set; }
    }
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
