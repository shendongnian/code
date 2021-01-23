    var sw = Stopwatch.StartNew();
    var spinWait = new SpinWait();
    while (youStillWantToProcess)
    {
        DoYourStuff();
        spinWait.Reset();
        while(sw.Elapsed < TimeSpan.FromMilliseconds(500))
            spinWait.SpinOnce();
        sw.Restart();
    }
