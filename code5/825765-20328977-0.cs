    private ManualResetEvent waitHandel;
    public void Sayhello()
    {
        Console.WriteLine("say hello");
        waitHandel.Set();
    }
    public void Saybye()
    {
        waitHandel.WaitOne();
        Console.WriteLine("say bye");
    }
    static void Main(string[] args)
    {
        waitHandel = new ManualResetEvent(false);
        Thread  th = new Thread(new ThreadStart(ob.Sayhello));
        th.Priority = ThreadPriority.Lowest;
        th.Start();
        Thread th1 = new Thread(new ThreadStart(ob.Saybye));
        th1.Priority = ThreadPriority.Highest;
        th1.Start();
        Console.ReadLine();
    }
    
