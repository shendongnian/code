    startfunction()
    {
        Parallel.ForEach(Enumerable.Range(0, 250), i => WorkThreadFunction(i));
    }
    public void WorkThreadFunction(int x)
    {
        try
        {
            // do some background work
        }      
        catch
        {
            //
        } 
    }
