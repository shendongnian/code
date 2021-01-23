    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Price> Prices { get; set; }
    }
    public class Price 
    {
        public virtual Guid Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public virtual decimal Price { get; set; }
    }
    
    public class Store
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ISet<Price> ProductPrices { get; set; }
    }
