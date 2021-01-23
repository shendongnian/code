        private void test()
        {
            Thread tid1 = new Thread(new ThreadStart(Thread1));
            Thread tid2 = new Thread(new ThreadStart(Thread2));
            tid1.Start();
            tid2.Start();
            Console.Write(string.Format("Done"));
        }
        static void Thread1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(string.Format("Thread1 {0}", i));
                Thread.Yield();
            }
        }
        static void Thread2()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(string.Format("Thread2 {0}", i));
                Thread.Yield();
            }
        }
