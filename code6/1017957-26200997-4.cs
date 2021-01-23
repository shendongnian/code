    var times = new List<double>();
    for (int i = 0; i < 4; i++)
    {
        var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.Blocking = true;
        var stopwatch = new Stopwatch();
        // Measure the Connect call only
        stopwatch.Start();
        sock.Connect(endPoint);
        stopwatch.Stop();
        double t = stopwatch.Elapsed.TotalMilliseconds;
        Console.WriteLine("{0:0.00}ms", t);
        times.Add(t);
        sock.Close();
        Thread.Sleep(1000);
    }
    Console.WriteLine("{0:0.00} {1:0.00} {2:0.00}", times.Min(), times.Max(), times.Average());
