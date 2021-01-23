    static void Main(string[] args)
    {
        var watch = new Stopwatch();
        watch.Start();
        var result = GetStringAsync(); 
        result.Wait();        
        var time = watch.ElapsedMilliseconds;
        
        Console.WriteLine(result.Result + ":" +  time);
    }
    static async Task<string> GetStringAsync()
    {
        var result1 = H1();
        var result2 = H2();
        var result3 = H3();
        
        await Task.WhenAll(result1,result2,result3);
       
        return result1.Result + result2.Result + result3.Result;            
    }
    static async Task<string> H1()
    {
        Console.WriteLine("entered h1");
        await Task.Delay(TimeSpan.FromSeconds(10));
        return "1";
    }
    static async Task<string> H2()
    {
        Console.WriteLine("entered h2");
        await Task.Delay(TimeSpan.FromSeconds(10));
        return "2";
    }
    static async Task<string> H3()
    {
        Console.WriteLine("entered h3");
        await Task.Delay(TimeSpan.FromSeconds(10));
        return "3";
    }
