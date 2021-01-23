    public void DoStuff()
    {
        using(var proxy = new Proxy())
        {
            proxy.Process().ContinueWith(result => Processed(result), TaskCreationOptions.None);
        }
    }
