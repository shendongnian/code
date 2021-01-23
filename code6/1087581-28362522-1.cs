    void ReadingLoop(BlockingCollection<Packet> queue, CancellationToken token)
    {
        while (!token.IsCancellationRequested) 
        {
           Packet packet = GetPacket();
           queue.Add(packet);
        }        
        queue.CompleteAdding();
    }
    void ProcessingLoop(BlockingCollection<Packet> queue, CancellationToken token)
    {
        List<Packet> report = new List<Packet>();
        try
        {
            foreach(var packet in queue.GetConsumingEnumerable(token))
            {
                report.Add(packet);
                if(packet.IsLastPacket)
                {
                    ProcessReport(report);
                    report = new List<Packet>();
                }
            }
        }
        catch(OperationCanceledException)
        {
            //Do nothing, we don't care that it happened.
        }
    }
    //This would replace your backgroundWorker.RunWorkerAsync() calls;
    private void StartUpLoops()
    {
        var queue = new BlockingCollection<Packet>(new ConcurrentQueue<Packet>());    
        var cancelRead = new CancellationTokenSource();
        var cancelProcess = new CancellationTokenSource();
        Task.Factory.StartNew(() => ReadingLoop(queue, cancelRead.Token));
        Task.Factory.StartNew(() => ProcessingLoop(queue, cancelProcess.Token));
        //You can stop each loop indpendantly by calling cancelRead.Cancel() or cancelProcess.Cancel()
    }
