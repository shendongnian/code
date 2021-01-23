    public void Run()
    {
        ProcessMethod(() => MethodA(1));
    }
    private void ProcessMethod(Action method)
    {
        method();
    }
