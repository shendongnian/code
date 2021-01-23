        async Task LongTask1() { ... }
        async Task LongTask2() { ... }
        ...
        {
           // Start the stopwatch
           var watch = new Stopwatch();
           watch.Start();
    
           // Do Async Tasks
           Task t1 = LongTask1();
           Task t2 = LongTask2();
           await Task.WhenAll(t1,t2); //now we have t1.Result and t2.Result          
           // Now we have the time it took to complete all the async tasks
           
           var time = watch.ElapsedMilliseconds;
        }
