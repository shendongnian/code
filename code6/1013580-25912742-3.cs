    static Timer tmrCheck = new Timer();
    static bool waiting = false;
    static void Main(string[] args)
    {
        Initialize();
        Console.WriteLine("Press enter to stop the processing....");
        Console.ReadLine();
        tmrCheck.Stop();
    }
    static void Initialize()
    {
        tmrCheck.Elapsed += (s, e) =>
        {
            Console.WriteLine("Timer event");
            if(!waiting)
            {
                Process[] p = Process.GetProcessesByName("yourprocessname");
                if(p.Length > 0)
                {
                    waiting = true;
                    Console.WriteLine("Waiting for exit");
                    p[0].WaitForExit();
                    Timer t = s as Timer;
                    t.Stop();
                    Console.WriteLine("Press enter to end application");
                }
            }
            else
            {
                // other processing activities
            }
        };
        tmrCheck.Interval = 10000;
        tmrCheck.Enabled = true; 
    }
