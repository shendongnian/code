    private int isWorking = 0;
    public void Foo()
    {
        if (Interlocked.Exchange(ref isWorking, 1) == 0)
        {
            try
            {
                //Do work
            }
            finally
            {
                Interlocked.Exchange(ref isWorking, 0);
            }
        }
    }
