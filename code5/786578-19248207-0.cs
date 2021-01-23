    void f() {
        var timer = new Timer(2000);
        timer.Elapsed += OnTimerElapsed;
        timer.Start ();
        Console.WriteLine ("Timer started, control is back here");
    }
    void OnTimerElasped (object o, EventArgs e)
    {
        Console.WriteLine ("tick");
    }
