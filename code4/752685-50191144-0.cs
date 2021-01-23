    static async Task DoWork1() // modified with try-catch
    {
        try
        {
            var t1 = DoTask1Async("t1.1", 3000);
            var t2 = DoTask2Async("t1.2", 2000);
            var t3 = DoTask3Async("t1.3", 1000);
            await t1; await t2; await t3;
            Console.WriteLine("DoWork1 results: {0}", String.Join(", ", t1.Result, t2.Result, t3.Result));
        }
        catch (Exception x)
        {
            // ...
        }
            
    }
