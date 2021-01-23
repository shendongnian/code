    public interface INamable
    {
      string Name { get; }
      string Surname { get; }
    }
    
    public class Foo : INamable
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
    }
