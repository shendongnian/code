    MyViewModel myViewModel = new MyViewModel();
    var task1 = myService.CalculateAnswer1Async();
    var task2 = myService.CalculateAnswer2Async();
    var results = await Task.WhenAll(task1, task2);
    myViewModel.Answer1 = results[0];
    myViewModel.Answer2 = results[1];
