    void Main()
    {
    	InvokeAction(Method1, "myString");
    	InvokeAction(Method2, "myString2");
    }
    
    void InvokeAction(Action<string> action, string param)
    {
    	action(param);
    }
    
    void Method1(string x)
    {
    	Console.WriteLine(x);
    }
    
    void Method2(string y)
    {
    	Console.WriteLine(y);
    }
