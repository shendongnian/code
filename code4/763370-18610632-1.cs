    private void DoWork<T>(ConcurrentQueue<T> queue,object objectType)
    {
        T outResult;// generic type
        while(queue.TryDequeue(out outResult))
        {
            //do something
        }
    }
