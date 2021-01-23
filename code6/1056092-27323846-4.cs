    static async Task ProcessSchedule(IEnumerable<DateTime> schedule)
    {
        // Release caller
        await Task.Yield();
        // Process the queue
        foreach (DateTime eventTime in schedule)
        {
            TimeSpan nextEvent = eventTime - DateTime.UtcNow;
            Console.Write(
                "waiting {0:0.000} seconds...", Math.Max(0, nextEvent.TotalSeconds));
            if (nextEvent.Ticks > 0)
            {
                await Task.Delay(nextEvent);
            }
            Console.WriteLine(eventTime);
        }
    }
