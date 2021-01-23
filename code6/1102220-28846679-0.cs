    class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
    }
    class Supplier
    {
        public Guid SupplierID { get; set; }
        public string SupplierName { get; set; }
    }
    
    class Category 
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
