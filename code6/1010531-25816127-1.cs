    public static async Task DoStuff()
    {
        while (true)
        {
            await Task.Run(() => SomeWork());
            await Task.Delay(TimeSpan.FromSeconds(30));
        }
    }
