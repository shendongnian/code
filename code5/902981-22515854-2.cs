    void Main()
    {
        SeveralCalls("Some other string",
                     otherValue => CallWithParams("test", otherValue), 
                     otherValue => CallWithParams("AnotherTest", otherValue));
    }
    
    public void SeveralCalls(string otherValue, params Action<string>[] methodsToCall)
    {
        foreach (var methodToCall in methodsToCall)
        {
            methodToCall(otherValue);
        }
    }
    
    public void CallWithParams(string someValue, string otherValue = null)
    {
        Console.WriteLine("SomeValue: " + someValue);
        Console.WriteLine("OtherValue: " + otherValue);
    }
