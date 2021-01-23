    private int _count;
    private readonly Object _locker_ = new Object();
    public void CheckForWork() {
        lock(_locker_)
        {
            if (_count >= MAXIMUM)
                return;
            _count++;
        }
        Task.Run(() => Work());
    }
    public void CompletedWorkHandler() {
        lock(_locker_)
        {
            _count--;
        }
        ...
    }
