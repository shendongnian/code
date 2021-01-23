    public event Func<A, EventArgs, Task> Shutdown;
    private async Task SomeMethod()
    {
        ...
        await Shutdown.Raise(this, EventArgs.Empty);
        ...
    }
