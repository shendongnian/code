    public abstract class Options{};
    public class CopyOptions : Options
    {
    }
    public abstract class Task<T> where T : Options
    {
      public string ID {get; set;}
      public string Name {get; set;}
      public T Options { get; set; }
      public abstract void Execute();
    }
    
    public class Copy : Task<CopyOptions>
    {
        public override void Execute()
        {
            Console.Write("running");
        }
    }
