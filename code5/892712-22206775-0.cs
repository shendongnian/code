    // --- Warm up --- ignore time here unless meauring startup perf.
    var timeStartGetStatistic = DateTime.Now.ToString("HH:mm:ss:fff");
    var timeEndGetStatistic = DateTime.Now.ToString("HH:mm:ss:fff"); 
    
    // Actual timing after JIT and all startup cost is payed.
    Stopwatch timer2 = Stopwatch.StartNew();
    // Consider multiple iterations i.e. to run code for about a second.
    var timeStartGetStatistic2 = DateTime.Now.ToString("HH:mm:ss:fff");
    var timeEndGetStatistic2 = DateTime.Now.ToString("HH:mm:ss:fff");
    timer2.Stop();
    Console.WriteLine("Convert take time {0}", timer2.Elapsed);
    
    Console.WriteLine("Second StopWatch\nStart:\t{0}\nStop:\t{1}",
        timeStartGetStatistic2, timeEndGetStatistic2);  
