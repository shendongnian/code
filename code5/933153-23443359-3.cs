    public async Task<int> DoSomethingWithUIAsync()
    {
        await Task.Delay(100);
        this.Title = "Hello!";
        return 42;
    }
    public async Task DoSomething()
    {
        var x = await Application.Current.Dispatcher.Invoke<Task<int>>(
            DoSomethingWithUIAsync);
        Debug.Print(x.ToString()); // prints 42
    }
