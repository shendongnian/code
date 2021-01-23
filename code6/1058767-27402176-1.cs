    [LogExecutionTimeAttribute]
    void MethodOne()
    {
       Thread.Sleep(200);     
    }
    void MethodTwo()
    {      
       Thread.Sleep(500);
    }
    [LogExecutionTimeAttribute]
    void MethodThree()
    { 
       Thread.Sleep(300); 
    }
    void StartFlow()
    {
       MethodOne();
       MethodTwo();
       MethodThree();
    }
