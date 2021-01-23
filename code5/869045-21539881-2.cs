    var tasks = methods.Select(method =>
    {
        Func<object> asyncFunction = () => DynamicCall(method, paramList);
    
        var task = Task.Factory.FromAsync(
            (asyncCallback, state) => asyncFunction.BeginInvoke(asyncCallback, state),
            (asyncResult) => asyncFunction.EndInvoke(asyncResult), 
            null);
    
        return Task.WhenAny(task, Task.Delay(timeout)).Unwrap();
    });
    
    Task.WhenAll(tasks).Wait(); // or Task.WaitAll();
