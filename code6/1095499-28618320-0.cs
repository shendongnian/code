    Queue<Tuple<string, Func<int>>> _queue = new Queue<Tuple<string, Func<int>>>();
    void Queue(Func<int> method, [CallerMemberName] string caller = null)
    {
        if (!_queue.Any(v => v.Item1 == caller))
            _queue.Enqueue(Tuple.Create(caller, method));
    }
    void QueueOne()
    {
        Queue(() => DoOne());
    }
    void QueueTwo(int val)
    {
        Queue(() => DoTwo(val));
    }
    int DoOne()
    {
        return 1;
    }
    int DoTwo(int val)
    {
        return val;
    }
