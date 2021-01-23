    interface IServiceA
    {
    	void DoSomething();
    }
    interface IServiceB
    {
    	void DoSomething();
    }
    class MyService : IServiceA, IServiceB
    {
    	void DoSomething(string parameter)
    	{
    		Console.WriteLine("I'm " + parameter);
    	}
    
    	void IServiceA.DoSomething()
    	{
    		DoSomething("service A");
    	}
    	
    	void IServiceB.DoSomething()
    	{
    		DoSomething("service B");
    	}
    }
