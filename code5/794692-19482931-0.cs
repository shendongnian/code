    // First is to use the Result property of the Task
    // This is not recommended as it makes the call synchronous, and ties up the UI thread
    string json = DataService.GetResult(url).Result;
    
    // Next is to continue work after the Task completes.
    DataService.GetResult(url).ContinueWith(t =>
    {
        string json = t.Result;
        // other code here.
    };
