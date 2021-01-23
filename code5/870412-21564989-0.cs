    void Main()
    {
    	List<Action> actions = new List<Action>
    	{
    		() => Method1("myString"),
    		() => Method2("myString2", "myString3")
    	};
    	foreach(var action in actions) InvokeAction(action);
    }
    
    void InvokeAction(Action action)
    {
    	action();
    }
    
    void Method1(string x)
    {
    	Console.WriteLine(x);
    }
    
    void Method2(string y, string z)
    {
    	Console.WriteLine(y);
    	Console.WriteLine(z);
    }
