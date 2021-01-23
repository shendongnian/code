    public void DoSomething(int? x)
    {
        if (x == null)
        {
            ...
        }
        else
        {
            // Or whatever
            Console.WriteLine(x.Value);
        }
    }
