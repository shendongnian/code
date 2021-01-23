    private PingReply ping(int tout,bool waitForSuccess)
    {
        PingReply replay = null;
        Ping ping = new Ping();
        Stopwatch stopWatch=new Stopwatch();
        stopWatch.Start();
        long timeOut=tout*1000;
        while (stopWatch.ElapsedMilliseconds < timeOut)
        {
            replay = ping.Send(m_device.IPAddress,2000);
            if((replay.Status == IPStatus.Success) == waitForSuccess)
                break;
            System.Threading.Thread.Sleep(2000);
        }
        return replay;
    }
