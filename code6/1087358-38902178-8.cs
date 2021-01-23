    public class Program
    {
  	  public static void Main()
  	  {
		Action<string> consoleWrite = null;
		
		consoleWrite?.Invoke("Test 1");
		
		consoleWrite = (s) => Console.WriteLine(s);
		
		consoleWrite?.Invoke("Test 2");
  	  }
    }
