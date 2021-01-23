    class PingJob
    {
        string IPAddress;
        int Period;  // milliseconds between pings
        TimeSpan NextPingTime;
    }
    var queue = new PriorityQueue<PingJob>();
    // create the ping jobs and add them to the queue
    queue.Add(new PingJob { IPAddress = "192.168.1.1", Period = 400, NextPingTime = TimeSpan.FromMilliseconds(400) });
    queue.Add(new PingJob { IPAddress = "10.10.200.50", Period = 42000, NextPingTime = TimeSpan.FromMilliseconds(42000) });
    // etc.
    // start a thread that processes the pings
    var pingTask = Task.Factory.StartNew(PingTaskProc, TaskCreationOptions.LongRunning);
