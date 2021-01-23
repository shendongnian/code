    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var result = TestThreadTimeOut();
                Console.WriteLine("Result: " + result);
            }
            catch (TimeoutException exp)
            {
                Console.WriteLine("Time out");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Other error! " + exp.Message);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
        public static string TestThreadTimeOut()
        {
            string result = null;
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Blah Blah Blah");
                }
            });
            t.Start();
            DateTime end = DateTime.Now + new TimeSpan(0, 0, 0, 0, 1500);
            while (DateTime.Now <= end)
            {
                if (result != null)
                {
                    break;
                }
                Thread.Sleep(50);
            }
            if (result == null)
            {
                try
                {
                    t.Abort();
                }
                catch (ThreadAbortException)
                {
                    // Fine
                }
                throw new TimeoutException();
            }
            return result;
        }
    }
