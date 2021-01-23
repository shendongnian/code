    Task aaa = Gateway.GetMyAAA();
    Task bbb = Gateway.GetBBBB();
    await Task.WhenAll(aaa, bbb);
    'all tasks are complete at this time. now we get the results
    var aaaResult = aaa.Result;
    var bbbResult = bbb.Result;
 
