    public async void DoWork()
    {
        Task cpuBoundTask = null;
        Task ioBoundTask = null;
        while(true)
        {
             ioBoundTask = DoIOBoundStuff();
             var ioResult = await ioBoundTask;
             if(cpuBoundTask != null)
             {
                 await cpuBoundTask;
             }
             cpuBoundTask = DoCpuBoundStuff(ioResult);
        }
     }
