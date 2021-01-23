    public void Destroy(List<PhantomProcessModel> discardedProcesses)
    {
        ThreadPool.QueueUserWorkItem( (someobj) => 
        {
            process.WaitForExit(15000);
            process.Close();
            process.Dispose();
            // instance members of List<> are not thread safe
            lock(discardedProcesses) 
            {
                discardedProcesses.Remove(this);
            }
        });
    }
