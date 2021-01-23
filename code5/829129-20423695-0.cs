    public class Product
    { 
        public virtual Guid Id {get;set;}
        public virtual string Name {get;set;}
        public virtual ProductDetails Details {get;set;}
    }
    public class ProductDetails
    { 
        public virtual Guid Product_Id {get;set;}
        public virtual string Details {get;set;}
    }
