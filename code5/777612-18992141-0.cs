    static void Main(string[] args)
    {
        Console.WriteLine(Environment.ProcessorCount);
        Console.Read();
        //An AffinityMask of 0x0001 will make sure the process is always pinned to processer 0
        Process thisProcess = Process.GetCurrentProcess();
        thisProcess.ProcessorAffinity = (IntPtr)0x0001; 
        const int ITERATIONS = 10000;
        const int FIBONACCI = 100000;
        var watch = new Stopwatch();
        watch.Start();
        DoFibonnacci(ITERATIONS, FIBONACCI);
        watch.Stop();
        Console.WriteLine("Total fibonacci time: {0}ms", watch.ElapsedMilliseconds);
        Console.ReadLine();
    }
