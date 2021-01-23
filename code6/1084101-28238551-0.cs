    public void Process()
    {
        for (int i = 0; i < 1000; i++)
        {
            Math.Sqrt(i);
        }
        
        Thread.Sleep(3000); // sync I/O
    }
