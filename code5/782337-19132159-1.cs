    static void Consume()
    {
        while(true)
        {
            if (WaitHandle.WaitOne(workPresent))
            {
                Queue<item> localWorkQueue = new Queue<item>();
                lock(workQueue)
                {
                    while (workQueue.Count > 0)
                        localWorkQueue.Enqueue(workQueue.Dequeue());
                    workPresent.Reset();
                }
                // Handle items in local work queue
                ...
            }
        }
    }    
