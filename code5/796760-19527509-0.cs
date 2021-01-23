        private static int _fileProcessed;
        private static Semaphore _pool;
        static void Main(string[] args)
        {
            // let say I have a list of file names in an array
            string[] files = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "z" };
            // we only want 10 threads working at one time
            _fileProcessed = 0;
            _pool = new Semaphore(10, 10);
            foreach (string file in files)
            {
                _pool.WaitOne();    // wait until I have a free resource 
                Thread t = new Thread(() => ProcessFile(file));
                t.Start();
            }
            // you can either wait here until are theads are done
            // or exit
            // In the example I want to wait
            while (_fileProcessed < files.Length)
            {
                Thread.Sleep(500);
            }
            Console.WriteLine("We are done!");
            //Console.ReadLine();
        }
        private static void ProcessFile(string fileName)
        {
            int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("{0} - {1:HH:mm:ss.fff} - Working on File: {2}", id, DateTime.Now, fileName);
            
            // Do Work ....
            
            // to simulate work getting done - get a number of seconds
            // between 10 & 30 seconds
            Thread.Sleep(GetWorkLength());
            Console.WriteLine("{0} - {1:HH:mm:ss.fff} - Worked Completed on file: {2}", id, DateTime.Now, fileName);
            Interlocked.Add(ref _fileProcessed, 1);         
            _pool.Release();
        }
        // Random work length
        private static Random _workLength = new Random();
        private static object _lock = new object();
        private static int GetWorkLength()
        {
            lock (_lock)
            {
                return _workLength.Next(10, 30) * 1000;
            }
        }
