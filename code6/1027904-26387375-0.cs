    public class Product
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
    
        //id or class relation? both!
        public int CategoryId {get;set;}
    
        public virtual Category Category {get;set;}
    }
