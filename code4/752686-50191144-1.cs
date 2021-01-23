    static async Task DoWork2() //modified to catch all exceptions
    {
        try
        {
            var t1 = DoTask1Async("t1.1", 3000);
            var t2 = DoTask2Async("t1.2", 2000);
            var t3 = DoTask3Async("t1.3", 1000);
            var t = Task.WhenAll(t1, t2, t3);
            await t.ContinueWith(x => { });
            Console.WriteLine("DoWork1 results: {0}", String.Join(", ", t.Result[0], t.Result[1], t.Result[2]));
        }
        catch (Exception x)
        {
            // ...
        }
    }
