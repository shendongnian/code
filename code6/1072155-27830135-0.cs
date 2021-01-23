    // Signature specifies Task<TResult>
    async Task<int> TaskOfTResult_MethodAsync()
    {
        int hours;
        // . . .
        // Return statement specifies an integer result.
        return hours;
    }
    
    // Calls to TaskOfTResult_MethodAsync
    Task<int> returnedTaskTResult = TaskOfTResult_MethodAsync();
    int intResult = await returnedTaskTResult;
    // or, in a single statement
    int intResult = await TaskOfTResult_MethodAsync();
    
    
    // Signature specifies Task
    async Task Task_MethodAsync()
    {
        // . . .
        // The method has no return statement.  
    }
    
    // Calls to Task_MethodAsync
    Task returnedTask = Task_MethodAsync();
    await returnedTask;
    // or, in a single statement
    await Task_MethodAsync();
