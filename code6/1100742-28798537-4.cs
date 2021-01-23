    public class Product
    {
      public int Id {get; set;}
      public string Name {get; set;}
      public virtual ICollection<ProductAccessoryLink> ProductAccessoryLinks {get; set}
    }
    public class Accessory
    {
       pubic int Id {get; set;}
       public string Name {get; set;}
       public virtual ICollection<ProductAccessoryLink> ProductAccessoryLinks {get; set}
    }
    public class Type
    {
      pubic int Id {get; set;}
      public string Name {get; set;}
    }
    public class ProductAccessoryLink 
    {
      public int ProductId {get; set;}
      public int AccessoryId {get; set;}
      public int TypeId {get; set}
      public int sort {get; set;}
      public string notes {get; set}
      public virtual Type Type {get; set;}
      public virtual Product Product {get; set;}
      public virtual Accessory Accessory {get;set;}
    }
