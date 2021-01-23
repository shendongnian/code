        private static async Task LongDelay(TimeSpan delay)
        {
            var start = DateTime.UtcNow;
            while (true)
            {
                var remaining = (delay - (DateTime.UtcNow - start)).TotalMilliseconds;
                if (remaining <= 0)
                    break;
                if (remaining > Int16.MaxValue)
                    remaining = Int16.MaxValue;
                await Task.Delay(TimeSpan.FromMilliseconds(remaining));
            }
        }
