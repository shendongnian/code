    readonly Semaphore _semaphore = new Semaphore(0, int.MaxValue);
    
    public void Enqueue<T>(T item)
    {
         _internalQueue.Enqueue(item);
         _semaphore.Release();  // Informs that deque task to unblock if waiting. Equivalent to the  WaitHandle.Set() method. Increases the semaphore counter
    }
    
    public T Dequeue()
    {
         _semaphore.WaitOne();   // Blocks as long as there are no items in the queue. Decreases the semaphore counter when "let through". Blocks the thread as long as semaphore counter is zero.
         return _internalQueue.Dequeue();
    }
