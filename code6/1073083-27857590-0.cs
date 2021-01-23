    private void Test()
    {
        Task task = Task.Factory.StartNew(() =>
        {
            Environment.FailFast("Test", new ApplicationException("Test"));
        });
    }
