    public void Reading<T>() where T : IDisposableThing, new()
    {
        using(var disposableThing = new T())
        {
            //do things
        }
    }
