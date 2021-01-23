    private static Timer timer;
    
    static void Main(string[] args)
    {
        timer = new Timer(state => workDone(), null, 0, 50000);
        // Hold program open...
        Console.ReadLine();
    }
    private static void workDone()
    {
        // Do work
    }
