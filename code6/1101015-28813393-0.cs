    public class Car
    {
      public int Id { get; set; }
      public int EngineId { get; set; }
      public Engine Engine { get; set; } 
    }
    public class Engine
    {
      public int Id { get; set; }
      public string EngineName{ get; set; } 
    }
