    public class JsonClass
    {
      public int Width { get; set; }
      public int Height { get; set; }
      public int NumStitches { get; set; }
      public Palette Palette { get; set; }
    }
    
    public class Palette
    {
      public IEnumerable<Thread> Threads { get; set; }
    }
    
    public class Thread
    {
      public string Name { get; set;}
      ...
    }
