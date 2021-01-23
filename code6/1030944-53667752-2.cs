    using (var container = Register())
    {
        var singleton = container.Resolve<HelloWcfServer>();
        using (var host = new ServiceHost(singleton, Settings.BaseUri))
        {
             // ...
        }
    }
