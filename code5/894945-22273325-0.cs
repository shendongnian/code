    // ..setup socket etc...
    var milliseconds = 100; // How long to sleep between each socket write.
    var lastSendTime = 0; 
    
    while(true)
    {
        var remainingMilliseconds = milliseconds - ((DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond) - lastSendTime);
    
        await Task.Delay(Math.Max(0, remainingMilliseconds));
        lastSendTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
    
        // .. socket send and receive..
        Console.WriteLine("[" + DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond + "]" + ":" + response);
    }
    
