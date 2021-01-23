    public class School
    {
      // Id and SchoolId are automatically recognized
      public int SchoolId { get; set; }    
      public string Name { get; set; }
      // use an IList so that you can Add()
      public IList<Class> Classes { get; set; }
    }
