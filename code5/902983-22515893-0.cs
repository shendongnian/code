    void Main()
    {
    	SeveralCalls(extra => CallWithParams("test", extra),
       		         extra => CallWithParams("AnotherTest", extra));
    }
    
    public void SeveralCalls(params Action<string>[] methodsToCall)
    {
    	foreach (var methodToCall in methodsToCall)
    	{
    		methodToCall("some other param");
    	}
    }
    
    public void CallWithParams(string someValue, string otherValue = null)
    {
    	Console.WriteLine("SomeValue: " + someValue);
    	Console.WriteLine("OtherValue: " + otherValue);
    }
