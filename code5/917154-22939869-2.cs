    public string WaitForIdleAndGetErrors()
    {
        while (queue.IsCompleted == false )
        {
           System.Threading.Thread.Current.Sleep(100);
        }
       return ErrorsOccurred;
    }
