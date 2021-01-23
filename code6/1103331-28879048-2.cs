    var aTask = GetAAsync();
    var bTask = GetBAsync();
    ...
    await Task.WhenAll(aTask, bTask);
    returnArr.Add(aTask.Result);
    returnArr.Add(bTask.Result);  
