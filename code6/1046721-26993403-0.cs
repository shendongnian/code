    public async Task<int> SomeOtherMethodAsync()
    {
        var resultTask1 = LongRunningThirdMethod();
        var resultTask2 = LongRunningForthMethod();
        
        await Task.WhenAll(resultTask1, resultTask2);
    
        return resultTask1.Result + resultTask2.Result;
    }
