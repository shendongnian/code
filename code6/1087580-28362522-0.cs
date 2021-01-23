    BlockingCollection<Packet> _queuedPackets = new BlockingCollection<Packet>(new ConcurrentQueue<Packet>());
    
    void readingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!( sender as BackgroundWorker ).CancellationPending) 
        {
           Packet packet = GetPacket();
           _queuedPackets.Add(packet);
        }        
        _queuedPackets.CompleteAdding();
    }
    void processingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        List<Packet> report = new List<Packet>();
        foreach(var packet in _queuedPackets.GetConsumingEnumerable())
        {
            report.Add(packet);
            if(packet.IsLastPacket)
            {
                ProcessReport(report);
                report = new List<Packet>();
            }
        }
    }
