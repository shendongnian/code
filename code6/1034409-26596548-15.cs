    var cts = new CancellationTokenSource();
    var pipeline = Pipeline.Create<dynamic, dynamic>(d =>
    {
        //Do something with data in step 1
        if (someConditionalCheck)
            cts.Cancel();
        return d; 
    }).Next<dynamic>(d =>
    {
        //do something with data is step 2
        if(someConditionalCheck)
            cts.Cancel();
        return d;
    });
    subscription = Observable.Interval(TimeSpan.FromMinutes(1)).Subscribe(_ =>
    {
        try
        {
            using (var conn = new SqlConnection("someConnectionString"))
            {
                conn.Open();
                foreach (var v in pipeline.Process(conn.Query("SOME SQL HERE", buffered: true), cts.Token))
                {
                    //Do something with or ignore the result
                }
            }
        }
        catch (AggregateException e)
        {
            //Investigate what happened, could be error in processing 
            //or operation cancelled
        }
        catch (Exception e)
        {
            //All other exceptions
        }
    });
