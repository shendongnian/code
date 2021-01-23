    public class Item {
      public string Name { get; set;}
      public string Prod { get; set;}
    }
    public class Product {
      public string ID { get; set;}
      public List<Item> Items { get; set; }
    }
    public class Products {
      public List<Product> Prods { get; set; }
    }
