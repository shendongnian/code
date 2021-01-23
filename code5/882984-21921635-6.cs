    async Task AsyncMethodStartMultipleCall(ServiceClient client)
    {
        var task1 = CallServiceAsync((callback) => client.DoSomething(callback));
        var task2 = CallServiceAsync((callback) => client.DoSomething(callback));
        var task3 = CallServiceAsync((callback) => client.DoSomething(callback));
    
        return TaskFactory.ContinueWhenAll(new [] { task1, task2, task3 }, (tasks) => 
        {
            Debug.Print("All completed!");
        });
    }
