    var cts = new CancellationTokenSource();
    var pipeline = Pipeline.Create<dynamic,bool>(d =>
    {
        //Do something with data
        if(someOtherBool)
            cts.Cancel();
        return someBool; //some bool if you succeeded or not
    });
    
    using (var conn = new SqlConnection("someConnectionString"))
    {
        conn.Open();
        foreach (var b in pipeline.Process(conn.Query("SOME SQL HERE", buffered: true), cts.Token))
        {
            Console.WriteLine(b?"Success":"Failure");
        }
    }
