    static void Main(string[] args)
    {
        bool done = false;
        ITimerActionList mylist = new TimerActionList();
        mylist.Add(new PrepareTimer { Seconds = 1 });
        mylist.Add(new WorkTimer { Seconds = 2 });
        mylist.Add(new CoolDownTimer { Seconds = 1 });
        mylist.OnCompletedEvent += (sender, e) =>
        {
            done = true;
        };
        mylist.Work();
        while (!done)
        {
            // timer is running
        }
        Console.WriteLine("Done!");
    }
