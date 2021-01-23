    CountDownEvent countDown = new CountDownEvent(250);
    startfunction()
    {
        countDown.Reset();
        start1step(250);
        countDown.Wait();
    }
    private void start1step(int i)
    {
        while (i-- > 0)
        {
            new Thread(WorkThreadFunction, i).Start();
        }
    }
    public void WorkThreadFunction(object o)
    {
        int x = (int)o;
        try
        {
            // do some background work
        }      
        catch
        {
            //
        } 
        finally
        {
            countDown.Signal();
        }
    }
