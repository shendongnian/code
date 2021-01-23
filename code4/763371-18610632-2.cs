    private void DoWork<T>(ConcurrentQueue<T> queue,object objectType) where T: IDisposable
    {
        T outResult;// generic type
        
        while(queue.TryDequeue(out outResult))
        {
            //do something
            outResult.Dispose();
        }
    }
