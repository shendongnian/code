        static CountdownEvent cde = new CountdownEvent(3);
        static SemaphoreSlim sem = new SemaphoreSlim(3);
        static void X()
        {
            new Thread(Waiter).Start();
            new Thread(Waiter).Start();
            new Thread(Waiter).Start();
            for (; ; )
            {
                cde.Wait();
                Debug.WriteLine("new round");
                cde.Reset(3);
                sem.Release(3);
            }
        }
        static void Waiter()
        {
            for (; ; )
            {
                sem.Wait();
                Thread.Sleep(1000);
                Debug.WriteLine("Waiter run");
                cde.Signal();
            }
        }
