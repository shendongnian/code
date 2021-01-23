    // The type of binding object for your dgview source.
    public class Product
    {
      public Product()
      {
        this.Version = new List<double>();
      }
  
      public int ID { get; set; }
      public string Name { get; set; }
      public List<double> Version { get; set; }
    }
