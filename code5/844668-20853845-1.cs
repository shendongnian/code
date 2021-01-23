    public void CreateAndRaise()
    {
        Pub p = new Pub();
        p.OnChange += (sender, e)
        => Console.WriteLine(“Subscriber 1 called”);
        p.OnChange += (sender, e)
        => { throw new Exception(); };
        p.OnChange += (sender, e)
        => Console.WriteLine(“Subscriber 3 called”);
        try
        {
            p.Raise();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions.Count);
        }
        // Displays
        // Subscriber 1 called
        // Subscriber 3 called
        // 1
    }
