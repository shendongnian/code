    void f() {
        StartTimer ();
        Console.WriteLine ("Timer started, control is back here");
    }
    async void StartTimer ()
    {
        while (true) {
            await Task.Delay (2000);
            Console.WriteLine ("tick");
        }
    }
