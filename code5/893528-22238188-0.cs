    // no multi-threading, one client
    var sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    using (var wc = new ServiceReference1.Service1Client())
    {
        for (int x = 0; x < 200; x++)
        {
            wc.GetData(x);
        }
    }
    sw.Stop();
    Console.WriteLine("plain for: {0} ms", sw.ElapsedMilliseconds);
    sw.Reset();
    // multi-threading, one wcf client
    sw.Start();
    using (var wc = new ServiceReference1.Service1Client())
    {
        Parallel.For(0, 200, x =>
            {
                wc.GetData(x);
            });
    }
    sw.Stop();
    Console.WriteLine("tpl  paralel for: {0} ms", sw.ElapsedMilliseconds);
    sw.Reset();
    // multi-threading, client per thread
    sw.Start();
    int cnt = 0;
    Parallel.For(
        0, 
        200, 
        () => { return new ServiceReference1.Service1Client(); },
        (x,pls,wc) =>
        {
            wc.GetData(x);
            System.Threading.Interlocked.Increment(ref cnt);
            return wc;
        }, 
        client => {client.Close(); ((IDisposable) client).Dispose();}
    );                
    sw.Stop();
    Console.WriteLine("tpl wc per thread paralel for: {0} ms ({1})", sw.ElapsedMilliseconds, cnt);
