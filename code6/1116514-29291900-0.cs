    public static void Main()
    {
        var p = new Program();
        p.LoopAsync().Wait();
    }
    public async Task LoopAsync()
    {
        for (int i = 0; i < 5; ++i)
        {
            try
            {
                Console.WriteLine(i);
                var result = await SomeTask();
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Error" + i);
            }
        }
    }
