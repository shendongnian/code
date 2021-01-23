    class ConsoleApplication1
    {
    	void Main()
    	{
    		Console.WriteLine("User:");
    		string user = Console.ReadLine();
    		Console.Write("Password:");//no new line!!!
    		string pass = Console.ReadLine();
    		Console.WriteLine(string.Format("The user {0} has the password {1}", user, pass));
    	}
    }
