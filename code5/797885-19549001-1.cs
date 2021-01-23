    // max is 1000 items in queue
    private int _count = 1000;
    
    private Queue<string> _myQueue = new Queue<string>();
    
    private static object _door = new object();
    
    public void AddItem(string someItem)
    {
        lock (_door)
        {
            while (_myQueue.Count == _count)
            {
                // reached max item, let's wait 'till there is room
                Monitor.Wait(_door);
            }
    
            _myQueue.Enqueue(someItem);
            // signal so if there are therads waiting for items to be inserted are waken up
            // one at a time, so they don't try to dequeue items that are not there
            Monitor.Pulse(_door);
        }
    }
    
    public string RemoveItem()
    {
        string item = null;
    
        lock (_door)
        {
            while (_myQueue.Count == 0)
            {
                // no items in queue, wait 'till there are items
                Monitor.Wait(_door);
            }
    
            item = _myQueue.Dequeue();
            // signal we've taken something out
            // so if there are threads waiting, will be waken up one at a time so we don't overfill our queue
            Monitor.PulseAll(_door);
        }
    
        return item;
    }
