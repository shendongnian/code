    private ManualResetEvent _wait = new ManualResetEvent(true);
    private string DoCalc(string input)
    {
        _wait.WaitOne();
        Console.WriteLine("Selected {0}", input);
        _wait.Reset();
        return input;
    }
    private void Update(string input)
    {
        Console.WriteLine("Update {0}", input);
        _wait.Set();
    }
