    private object _sync = new object();
    private Message _beingProcessed;
    private Message _waitingToBeProcesssed;
    public void OnMessageReceived(Message message)
    {
        lock(sync)
        {
            _waitingToBeProcesssed = message;
            Monitor.Pulse(sync);
        }
    }
    public void DoWork()
    {
        while (true)
        {
            lock (sync)
            {
                while (_waitingToBeProcesssed == null)
                {
                    Monitor.Wait(sync);
                }
                _beingProcessed = _waitingToBeProcesssed;
                _waitingToBeProcesssed = null;
            }
            Process(_beingProcessed); //Do the actual work
        }
    }
