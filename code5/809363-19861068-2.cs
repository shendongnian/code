    public class Product
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public virtual ICollection<Category> Categories {get;set;}
    }
    
    public class Category
    {
       public int Id {get;set;}
       public string Name {get;set;}
       public int ProductId {get;set;}
       public virtual Product Product {get;set;}
    }
