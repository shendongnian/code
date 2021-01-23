    Stopwatch timer = Stopwatch.StartNew();
    TimeSpan dt = TimeSpan.FromSeconds(1.0/50.0);
    TimeSpan elapsedTime = TimeSpan.Zero;
    while(window.IsOpen())
    {
        timer.Restart();
        elapsedTime = timer.Elapsed;
        while(elapsedTime > dt)
        {
            window.DispatchEvents();
            elapsedTime -= dt;
            gameObject.FixedUpdate(dt.TotalMilliseconds);
        }
     }
