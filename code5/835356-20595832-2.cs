    public class ConsoleWrapper : IConsole
    {
         public void Write(string message)
         {
              Console.WriteLine(message);
         }
    }
