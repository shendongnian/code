    public async Task DoSomethingWithUIAsync()
    {
        await Task.Delay(100);
        this.Title = "Hello!";
    }
    public async Task DoSomething()
    {
        await Application.Current.Dispatcher.Invoke<Task>(DoSomethingWithUIAsync);
    }
