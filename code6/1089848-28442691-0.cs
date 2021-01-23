    public abstract class Task
    {
      public string ID {get; set;}
      public string Name {get; set;}
      public Options Options {get; set;}
      public abstract void Execute();
    
      public abstract class Options{};
    }
