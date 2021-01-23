    class User {
        public int Id { get; set; }
        public string Status { get; set; }
        public IList<Product> Products { get; set; }
    }
    
    class Product {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
