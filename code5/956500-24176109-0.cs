    void Run()
    {
        sem.WaitOne();
        if (Convert.ToInt32(Thrd.Name) == flag)
        {
            Console.WriteLine("Thread " + Thrd.Name);
            flag++;
        }
        if (flag == 4)
            flag = 1;
        Thread.Sleep(300);
        sem.Release();
    }
