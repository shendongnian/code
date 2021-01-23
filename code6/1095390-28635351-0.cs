    class Order
    {
        // properties you want to expose
        public DateTime OrderDate { get; set; }
        // navigation and other properties you don't want to expose
        public Guid OrderId { get; set; }
    
        public Customer Customer { get; set; }
    
        public ICollection<Address> Addresses { get; set; }
    
        public ICollection<Tax> Taxes { get; set; }
    }
    
    class OrderViewModel
    {
        public DateTime OrderDate { get; set; }
    }
