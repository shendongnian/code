    Pubnub pn = new Pubnub(publishKey, subscribeKey, secretKey, cipherKey, enableSSL);
    
    var tcs = new TaskCompletionSource<PubnubResult>();
    
    pn.HereNow("testchannel", res => //doesn't return a Task
    { //response
        tcs.SetResult(res);
    }, err =>
    { //error response
        tcs.SetException(err);
    });
    
    // blocking wait here for the result or an error
    var res = tcs.Task.Result; 
    // or: var res = tcs.Task.GetAwaiter().GetResult();
