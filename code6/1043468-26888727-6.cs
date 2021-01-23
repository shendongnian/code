    Dictionary<string, Thread> _threads = new Dictionary<string, Thread>();
    
    foreach (string addr in IpAddresses)
    {
        _threads.Add(addr, new System.Threading.Thread(
            new System.Threading.ParameterizedThreadStart(
                (object ip) =>
                {
                    // process ip. 
                }, addr)));
        _threads[addr].Start();
    }
