    public void Reading<T>() where T : new()
    {
        using(var disposableThing = new T())
        {
            //do things
        }
    }
