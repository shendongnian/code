        private static async Task LongDelay(TimeSpan delay)
        {
            var st = new System.Diagnostics.Stopwatch();
            st.Start();
            while (true)
            {
                var remaining = (delay - st.Elapsed).TotalMilliseconds;
                if (remaining <= 0)
                    break;
                if (remaining > Int16.MaxValue)
                    remaining = Int16.MaxValue;
                await Task.Delay(TimeSpan.FromMilliseconds(remaining));
            }
        }
