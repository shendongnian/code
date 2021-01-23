    void PingTaskProc()
    {
        var pingTimer = Stopwatch.StartNew();
        while (true)
        {
            var p = queue.Dequeue(); // get ping job
            if (p.NextPingTime > pingTimer.Elapsed)
            {
                // wait for ping time to come up
                Thread.Sleep(p.NextPingTime - pingTimer.Elapsed);
            }
            // ping the IP address
            DoPing(p.IPAddress);
            // update its next ping time
            p.NextPingTime += TimeSpan.FromMilliseconds(p.Period);
            // And add it back to the queue
            queue.Add(p);
        }
    }
