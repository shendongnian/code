    ManualResetEvent mreComplete = new ManualResetEvent(false);
    int callsRemaining;
    GetMergeSectionCaller caller = new GetMergeSectionCaller(GetMergeSection);
    callsRemaining = anObjectList.Count;
    mreComplete.Reset();
    foreach (var r in anObjectList) {
        ThreadPool.QueueUserWorkItem((Action)delegate {
            caller(r.ToString());
            lock{
               if(--callsRemaining==0) mreComplete.Set();
            }
        }
    }
    mreComplete.Wait();
    
