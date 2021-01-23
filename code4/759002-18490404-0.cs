    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GcTest();
            Console.Read();
        }
        private static void GcTest()
        {
            Class cls = new Class();
            Thread.Sleep(10);
            cls = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
    public class Class
    {
        private Thread _thread;
        ~Class()
        {
            Console.WriteLine("~Class");
            _thread.Abort();
            _thread = null;
        }
        public Class()
        {
            _thread = new Thread(ThreadProc);
            _thread.Start();
        }
        private void ThreadProc()
        {
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
