    MyService ws = new MyService ();
    
    System.Threading.Timer timer;
    
    protected override void OnStart(string[] args)
    {
        ...
    
        if (timer1 != null)
            timer1.Dispose();
    
        timer1 = new System.Threading.Timer(callback, null,
            next5am - DateTime.Now, TimeSpan.FromHours(24));
     }
