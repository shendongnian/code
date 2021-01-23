    for (int i = 0; i < tsk.Length; i++)
    {
        tsk[i] = Task.Factory.StartNew((object obj) =>
        {
            StopWatch watch = StopWatch.StartNew();
            resp = http.SynchronousRequest(web, 443, true, req);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }, i);
    }
