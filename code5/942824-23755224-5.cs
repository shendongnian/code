    public void Main()
    {
        Reading(new DisposableThingImplementation());
    }
    public void Reading(IDisposableThing disposableThing)
    {
        using (disposableThing)
        {
            //do things
        }
    }
