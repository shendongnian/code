    void Run()
    {
        bool success = false;
        while (!success)
        {
            sem.WaitOne();
            if (Convert.ToInt32(Thrd.Name) == flag)
            {
                Console.WriteLine("Thread " + Thrd.Name);
                flag++;
                success = true;
            }
            sem.Release();
            if (!success)
            {
                // let somebody else try
                Thread.Sleep(300);
            }
        }
    }
