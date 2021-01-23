    // you only need to synchronize if you are receiving results in parallel
    private readonly ISubject<Tuple<int,IResult>, Tuple<int,IResult>> results =
        Subject.Synchronize(new Subject<Tuple<int,IResult>>());
	
    private Task<IResult> SendMessageAndWaitForResponse(
        int endpoint, object message, TimeSpan timeout)
    {			
        // your message processing here, I'm just echoing a second later
        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => {
            CompleteWaitForResponseResponse(endpoint, new Result { Value = message }); 
        });
	
        return results.Where(r => r.Item1 == endpoint)
                      .Select(r => r.Item2)
                      .Take(1)
                      .Timeout(timeout)
                      .ToTask();
    }
	
    public void CompleteWaitForResponseResponse(int endpoint, IResult value)
    {
        results.OnNext(Tuple.Create(endpoint,value));
    }
