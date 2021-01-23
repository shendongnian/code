    var myResultVar = await Task.Run<MyResult> (() => MyFunctionWhichReturns() );
    public MyResult MyFunctionWhichReturns()
    {
       return new MyResult();
    }
