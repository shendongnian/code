    static void Main(string[] args)
    {
        int result;
        while (true)  // always true, it will always repeat
        {
            result = GetIntFromConsole("Kod");
            while (result != 1946)
            {
                Console.WriteLine("Locked");
                Thread.Sleep(4000); // 4 seconds = 4000 milliseconds
                result = GetIntFromConsole("Kod");
            } 
            Console.WriteLine("Unlocked");
            Thread.Sleep(4000);
        }
    }
