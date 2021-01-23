    private Queue<string> _incomingQueue = new Queue<string>();
    public Queue<string> IncomingQueue
    {
        get { return _incomingQueue; }
        set { _incomingQueue = value; }
    }
