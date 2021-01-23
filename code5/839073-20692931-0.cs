    public bool callingmethod(int num1, int num2)
    {
        Task.Factory.StartNew(() =>
        {
            employee emp = new employee();
            emp.method(num1, num2);
        }).ContinueWith(x => Console.WriteLine(x.Exception.ToString()), TaskContinuationOptions.OnlyOnFaulted);
        return true;
    }
