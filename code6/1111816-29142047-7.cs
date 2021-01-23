    class ConsoleApplication1
    {
    	void Main()
    	{
    		Console.WriteLine("User:");
    		object user = Console.ReadLine();
    		Console.Write("Password:");
    		object pass = Console.ReadLine();
    		Console.WriteLine(string.Format("The user {0} has the password {1}", user, pass));
    	}
    }
