    private void MyTest()
    {
        Func<string> foo = Bar;
    
        foo.BeginInvoke(BarComplete, null);
    }
    
    private string Bar()
    {
        return "Success";
    }
    
    private void BarComplete(IAsyncResult ar)
    {
        var uncastResult = foo.EndInvoke(ar); //This returns a "object", but it would still work with WriteLine
    
        var castResult = (string)uncastResult;
    
        Console.WriteLine(uncastResult); // Should print "Success"
        Console.WriteLine(castResult); // Should also print "Success"
    }
