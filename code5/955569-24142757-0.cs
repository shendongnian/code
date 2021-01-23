    void DoSomethingWithRunnables(IEnumerable<IRunnable> runnables)
    {
        ...
        foreach (var item in runnables)
        {
            item.Run();
        }
        ...
    }
