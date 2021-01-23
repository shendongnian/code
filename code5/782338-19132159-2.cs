    ManualResetEvent workPresent = new ManualResetEvent(false);
    Queue<item> workQueue = new Queue<item>();
    static void Produce()
    {
        while(true)
        {
            // Produce item;
            lock(workQueue)
            {
                workQueue.Enqueue(newItem);
                workPresent.Set();
            }
        }
    }
