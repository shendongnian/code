    private Queue<Transfer> _queue = null;
    public Queue<Transfer> Queue
    {
        get { return _queue; }
        set { _queue = value; }
    }
    void TransferFromQueue()
    {
        while(Queue.Count > 0)
        {
            Transfer current = Queue.Dequeue(); // removed
            // use Queue.Peek() if you want to look at it witout removing it
            // Do stuff
        }
    }
