    Queue<Data> _dataQueue = new Queue<Data>();
    void OnTimer()
    {
        //queue data for the other thread
        lock (_dataQueue)
        {
            _dataQueue.Enqueue(new Data());
        }
    }
    
    void ThreadMethod()
    {
        while (_threadActive)
        {
            Data data=null;
            //see if there is data from the other thread and remove it from the queue and process it if there is
            lock (_dataQueue)
            {
                if (_dataQueue.Count > 0)
                    data = _dataQueue.Dequeue();
            }
            //doing the processing outside the lock is important if the processing takes
            //some time, otherwise the main thread will be blocked when trying to add
            //new data
            if (data != null)
                ProcessData(data);
            //don't delay if there is more data to process
            if (_dataQueue.Count > 0)
                continue;
            Thread.Sleep(100);
        }
    }
