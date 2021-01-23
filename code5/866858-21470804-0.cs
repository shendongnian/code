    public Stuff GetStuff(CancellationToken token) 
    {
        var stuff = new Stuff();
        using (var stuffGetter = new StuffGetter()) 
        {
            stuffGetter.CancelCallback = () => token.IsCancellationRequested;
            for (var x = 0; x < 10; x++) 
            {
                token.ThrowIfCancellationRequested();
                var thing = stuffGetter.GetSomething();
                stuff.AddThing(thing);
            }
            return stuff;
        }
    }
