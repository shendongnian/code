    private Program(int i)
    {
        // base ctor
        base.ctor();
        // field initializers
        p = new Program();
        // now comes the ctor body
        Console.WriteLine(i.ToString());
    }
