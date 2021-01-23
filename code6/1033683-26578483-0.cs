    async Task Do()
    {
        for (int i = 0; i < 10000; i++)
        {
            Math.Pow(i,i);
        }
        
        await Task.Delay(10000);
    }
