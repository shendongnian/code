    private object syncObj = new object();
    void ThreadBody(object boxed)
    {
        Params params = (Params)boxed;
        lock (syncObj)
        {
            Monitor.Wait(syncObj);
        }
        // do work here
    }
    struct Params
    {
        // passed values here
    }
    void InitializeThreads()
    {
        int threads = Convert.ToInt32(txtThreads.Text);
        List<Thread> workerThreads = new List<Thread>();
        string from = txtStart.Text, to = txtEnd.Text;
        uint current = from.ToUInt(), last = to.ToUInt();
        ulong total = last - current;
        for (int i = 0; i < threads; i++)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(this.ThreadBody, new Params { /* initialize values here */ }));
            workerThreads.Add(thread);
            thread.Start();
        }
        lock(syncObj)
        {
            Monitor.PulseAll(syncObj);
        }
    }
