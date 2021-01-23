        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "1", "2", "3", "4" };
            List<string> list2 = new List<string> { "a", "b", "c", "d" };
            List<string> list3 = new List<string> { "*", "+", "-", "?" };
            using (EventWaitHandle waitHandle1 = new AutoResetEvent(false))
            using (EventWaitHandle waitHandle2 = new AutoResetEvent(false))
            using (EventWaitHandle waitHandle3 = new AutoResetEvent(false))
            using (EventWaitHandle waitHandle4 = new AutoResetEvent(false))
            {
                Thread t1 = new Thread(PrintItemWhenSignaled);
                Thread t2 = new Thread(PrintItemWhenSignaled);
                Thread t3 = new Thread(PrintItemWhenSignaled);
                t1.Start(new ThreadData() { Strings = list1, WaitHandle = waitHandle1, SignalHandle = waitHandle2 });
                t2.Start(new ThreadData() { Strings = list2, WaitHandle = waitHandle2, SignalHandle = waitHandle3 });
                t3.Start(new ThreadData() { Strings = list3, WaitHandle = waitHandle3, SignalHandle = waitHandle4 });
                for (int index = 0; index < list1.Count; index++)
                {
                    waitHandle1.Set();
                    waitHandle4.WaitOne(100);
                }
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        private static void PrintItemWhenSignaled(object state)
        {
            ThreadData threadState = state as ThreadData;
            foreach (string value in threadState.Strings)
            {
                threadState.WaitHandle.WaitOne(100);
                Console.WriteLine(value);
                threadState.SignalHandle.Set();
            }
        }
        public class ThreadData
        {
            public EventWaitHandle WaitHandle { get; set; }
            public EventWaitHandle SignalHandle { get; set; }
            public List<string> Strings { get; set; }
        }
