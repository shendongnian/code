    string otherValue = null;
    void Main()
    {
        SeveralCalls(() => CallWithParams("test", this.otherValue), 
                     () => CallWithParams("AnotherTest", this.otherValue));
    }
    
    public void SeveralCalls(params Action[] methodsToCall)
    {
        this.otherValue = "Some other string";
        foreach (var methodToCall in methodsToCall)
        {
            methodToCall();
        }
    }
    
    // added static just to clarify that the otherValue here is separate from the 
    // one in 'this'
    public static void CallWithParams(string someValue, string otherValue = null)
    {
        Console.WriteLine("SomeValue: " + someValue);
        Console.WriteLine("OtherValue: " + otherValue);
    }
