    someInstance.SomethingHappened += (msg) =>
        {
            //your code
        };
---
    public delegate void SomethingHappenedHandler(string s);
    public SomethingHappenedHandler SomethingHappened = null;
    public void DoSomething()
    {
        string message = Encoding.ASCII.GetString(data);
        Console.WriteLine(message);
        var sh = SomethingHappened;
        if (sh != null) sh(message);
    }
