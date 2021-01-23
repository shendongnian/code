    class BadAssClub
    {
        static SemaphoreSlim sem = new SemaphoreSlim(3);
        static void Main()
        {
            for (int i = 1; i <= 5; i++) 
                new Thread(Enter).Start(i);
        }
        
        // Enfore only three threads running this method at once.
        static void Enter(int i)
        {
            try
            {
                Console.WriteLine(i + " wants to enter.");
                sem.Wait();
                Console.WriteLine(i + " is in!");
                Thread.Sleep(1000 * (int)i);
                Console.WriteLine(i + " is leaving...");
            }
            finally
            {
                sem.Release();
            }
        }
    }
