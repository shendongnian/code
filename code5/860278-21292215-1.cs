    var taskList = new List<Task>();
    foreach (var myString in listOfStrings)
    {
        // Avoid closure issue
        var temp = myString;
        taskList.Add(Task.Factory.StartNew(async object stringObject => {
            var currentString = stringObject as string;
            //creating an object RequestDataObj
            RequestDataObj request = new RequestDataObj();
            //filling RequestDataObj with some request data based on currentString
            //making async call and getting data in resultDataObj 
            var resultDataObj = await ApiCall.GetDataAsync(request, currentString);
            //saving resultDataObj + currentString to database synchronously
        }, temp));
    }
    await Task.WhenAll(taskList);
    //doing some other operations here
