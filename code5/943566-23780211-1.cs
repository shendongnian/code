    static void Main(string[] args)
    {
        DoWorkAsync().Wait();
    }
    static async Task DoWorkAsync()
    {
        Weather bot = new Weather();
        if (bot.IsRunning)
        {
            await bot.Update();
        }
    }
