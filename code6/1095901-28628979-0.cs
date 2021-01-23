    static void Main(string[] args)
    {
        List<Thread> ts = new List<Thread>();
    
        for(int i = 0; i < 20; i++)
        {
            var closureIndex = i;
            Thread t = new Thread(() =>
            {
                UdpPortListener(Convert.ToUInt16(52000 + closureIndex));
            });
    
            t.IsBackground = false;
    
            ts.Add(t);
        }
    
        ts.ForEach((x) => x.Start());
    }
