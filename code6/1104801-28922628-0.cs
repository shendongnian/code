    var timer = new System.Timers.Timer(10000);
    timer.Elapsed += OnChangePictureEvent;
    private static void OnChangePicture(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
    }
