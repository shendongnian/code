    private static readonly TimeSpan FullDelay = TimeSpan.FromMilliseconds(int.MaxValue);
    
    private static async Task LongDelay(TimeSpan delay)
    {
        long fullDelays = delay.Ticks / FullDelay.Ticks;
        TimeSpan remaining = delay;
        for(int i = 0; i < fullDelays; i++)
        {
            await Task.Delay(FullDelay);
            remaining -= FullDelay;
        }
        
        await Task.Delay(remaining); 
    }
