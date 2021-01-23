    using System.Collections.Async;
    public async Task<MyResult> GetResult()
    {
        MyResult result = new MyResult();
    
        await Methods.ParallelForEachAsync(async method =>
        {
            string json = await Process(method);    
    
            result.Prop1 = PopulateProp1(json);
            result.Prop2 = PopulateProp2(json);
        });
    
        return result;
    }
