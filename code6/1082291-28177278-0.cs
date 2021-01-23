    var timer = new System.Timers.Timer { ... };
    timer.Elapsed += Foo;
    timer.Start();
    ...
    private async void Foo()
    {
        ...
    }
