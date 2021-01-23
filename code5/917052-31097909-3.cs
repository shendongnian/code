    var loadTest = NLoad.Test<MyTest>()
                          .WithNumberOfThreads(500)
                          .WithDurationOf(TimeSpan.FromMinutes(5))
                          .WithDeleyBetweenThreadStart(TimeSpan.FromMilliseconds(100))
                          .OnHeartbeat((s, e) => Console.WriteLine(e.Throughput))
                        .Build();
    
    var result = loadTest.Run();
