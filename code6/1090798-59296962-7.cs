    Action DebounceToConsole;
    int count = 0;
    
    void Main()
    {
    	//Assign
    	DebounceToConsole = ((Action)ToConsole).Debounce(50);
    
    	var random = new Random();
    	for (int i = 0; i < 50; i++)
    	{
    		DebounceToConsole();
    		Thread.Sleep(random.Next(100));
    	}
    }
    
    public void ToConsole()
    {
    	Console.WriteLine($"I ran for the {++count} time.");
    }
