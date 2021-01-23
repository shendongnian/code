    public void Main()
    {
        using(var disposableThing = new DisposableThingImplementation())
            Reading(disposableThing);
    }
    public void Reading(IDisposableThing disposableThing)
    {
        //do things
    }
