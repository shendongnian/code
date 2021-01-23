    static void Main(string[] args)
    {
        string name = "NetMMFSingle";
        // Create named MMF
        try
        {
            var mmf = MemoryMappedFile.CreateNew(name, 1);
        } catch
        {
            Console.WriteLine("Instance already running...");
            return;
        }
        ConsoleKeyInfo key = Console.ReadKey();
        // Your real code follows...
    }
