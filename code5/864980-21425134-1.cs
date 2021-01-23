    public abstract class BaseProgram
    {      
      protected BaseProgram()
      {
        Console.Title = "Some Title";
        // other common initialization
      }
      public abstract void Run(string[] args);
      public void WriteMessage(string message, TypeMessage typeMessage = TypeMessage.Log)
      {
        ...
      }
      
      // other methods
    }
    public class Program : BaseProgram
    {
      public static void Main(string[] args)
      {
        var program = new Program();
        program.Run(args);        
      } 
      public override void Run(string[] args)
      {
        //do stuff
        WriteMessage("Sucess .... etc", TypeMessage.Success);
      }
    }
