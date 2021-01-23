    void Run()
    {
        // some initialization stuff
        new Thread(DoWork1) { Priority = ThreadPriority.AboveNormal }.Start();
        new Thread(DoWork2) { Priority = ThreadPriority.Highest }.Start();
    }
    private void DoWork2()
    {
        while (action)
        {
            if (doItAlways)
            {
                //do important tasks
            }
            if (task1)
            {
                //do things
                task1 = false;
            }
            if (task2)
            {
                //do things
                task1 = false;
            }
            Thread.Sleep(1);
        }
    }
    private void DoWork1()
    {
        task1 = true;
        Thread.Sleep(12000);//call delay class to wait 12 secs
        task2 = true;
        Thread.Sleep(12000);//call delay class to wait 12 secs
    }
