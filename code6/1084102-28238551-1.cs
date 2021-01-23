    public async Task ProcessAsync()
    {
        for (int i = 0; i < 1000; i++)
        {
            Math.Sqrt(i);
        }
        
        await Task.Delay(3000) // async I/O
    }
