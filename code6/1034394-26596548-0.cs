    var pipeline = Pipeline.Create<SomeType, bool>(st =>
    {
        //Do something with st
        return someBool; //some bool if you succeeded or not
    });
    var cts = new CancellationTokenSource();
    //cancel after 10s (just for fun)
    Observable.Timer(TimeSpan.FromSeconds(10)).Subscribe(s => cts.Cancel());
    using (var conn = new SqlConnection("someConnectionString"))
    {
        conn.Open();
        pipeline.Process(conn.Query<SomeType>("SOME SQL HERE", buffered:true),cts.Token);
    }
