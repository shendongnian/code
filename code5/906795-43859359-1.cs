    static async void WorkAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Done!");
    }
    static async Task StartWorkAsync()
    {
        WorkAsync(); // no warning since return type is void
        // more unrelated async/await stuff here, e.g.:
        // ...
        await Task.Delay(2000); 
    }
