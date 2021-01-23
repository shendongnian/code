    class Program
    {
        static AutoResetEvent ar = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            //register the callback
            ThreadPool.RegisterWaitForSingleObject(ar, 
                       new WaitOrTimerCallback(ThreadProc), 
                       null, -1, false);
            // Queue the task 
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), null);
            Console.ReadLine();
        }
        // This thread procedure performs the task specified by the 
        // ThreadPool.QueueUserWorkItem
        static void ThreadProc(Object stateInfo)
        {
            //Write to the XML file and close the file, then notify the main thread
            ar.Set();
        }
        // This thread procedure performs the task specified by the 
        // ThreadPool.RegisterWaitForSingleObject
        static void ThreadProc(Object stateInfo, bool timedOut)
        {
            //restart the system
        }
    }
