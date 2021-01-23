    public class Product {
      // You don't need any CSV here: CSV is the representation of the data
      public int ProductId { get; set; }
      public string Name { get; set; }
      public int Quantity { get; set; }
    
      // Just a constructor: no CSV at all
      public Product(): base() {
      }
    
      public static Product FromCsv(String csvValue) {
        //TODO: Parse csvValue here, throw ArgumentException on incorrect csvValue
        if (null == csvValue)
          throw new ArgumentNullException("csvValue");
        ...  
    
        Product result = new Product();
    
        //TODO: Assign ProductId, Name, Quantity properties here
        result.ProductId = ...
    
        return result; 
      }
    
      public String ToCsv() {
        // Simplest implemenation, Name is not expected to have either ',' or '"'
        return ProductId.ToString() + "," + Name + "," + Quantity.ToString();
      }
    }
