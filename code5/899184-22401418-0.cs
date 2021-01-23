    MyViewModel myViewModel = new MyViewModel();
    Task<int>[] tasks = new []
    {
       myService.CalculateAnswer1Async();
       myService.CalculateAnswer2Async();
    };
    
    Task.WaitAll(tasks);
    
    myViewModel.Answer1 = tasks[0].Result;
    myViewModel.Answer2 = tasks[1].Result;
