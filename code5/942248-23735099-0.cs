        static void Main(string[] args)
        {
            const int count = 10;
            var waitHandles = new ManualResetEvent[count];
            ThreadPool.SetMaxThreads(5, 5);
            for (int x = 0; x < count; x++)
            {
                var handle = new ManualResetEvent(false);
                waitHandles[x] = handle;
                var worker = new MyWorker(handle, x);
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyWorker.printnum), worker);
            }
            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }
        class MyWorker
        {
            readonly ManualResetEvent handle;
            readonly int number;
            public MyWorker(ManualResetEvent handle, int number)
            {
                this.handle = handle;
                this.number = number;
            }
            public static void printnum(object obj)
            {
                var worker = (MyWorker)obj;
                Console.WriteLine("Call " + worker.number);
                for (int i = 0; i < 10; i++) { Console.WriteLine(i); }
                // we are done
                worker.handle.Set();
            }
        }
