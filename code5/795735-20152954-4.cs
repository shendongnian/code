    public static Task<string> GetSomeStringAsync()
    {
        var doSomething = Task.Factory.StartNew(() => "bar");
        return doSomething.WrapExceptions(typeof(IOException), typeof(WebException));
    }
