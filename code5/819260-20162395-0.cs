    public void DoStuff()
    {
        using(var proxy = new Proxy())
        {
            var result = await proxy.Process();
            Task.Run(() => Processed(result));
        }
    }
