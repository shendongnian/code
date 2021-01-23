    IObservable<Foo> foos = //...;
    var pub = foos.Publish();
    var windows = pub.Select(x => new DateTime(
        x.Ticks - x.Ticks % TimeSpan.FromSeconds(5).Ticks)).DistinctUntilChanged().Publish.RefCount();
    
    pub.Buffer(windows, x => windows).Subscribe(x => t.Dump()));
    pub.Connect();
