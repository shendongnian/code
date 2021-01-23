    class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int? MallId { get; set; }
        public virtual GeoMarket Market { get; set; }
        public virtual Mall Mall { get; set; }
    }
    
    class StandAloneStore : Store
    {
        public Address Address { get; set; }
    }
    
    class Address
    {
        public string Address_Line1 { get; set; }
    
        public string Address_Line2 { get; set; }
    
        public string City { get; set; }
    
        public string Zipcode { get; set; }
    }
    
    class Mall
    {
        public int MallId { get; set; }
    
        public string Name { get; set; }
    
        public Address Address { get; set; }
    
        public virtual GeoMarket Market { get; set; }
    
        IList<Store> Stores { get; set; }
    }
