    public static class TaskEx
    {
        /// <summary>
        /// Blocks while condition is true or timeout occurs.
        /// </summary>
        /// <param name="condition">The condition that will perpetuate the block.</param>
        /// <param name="frequency">The frequency at which the condition will be check, in milliseconds.</param>
        /// <param name="timeout">Timeout in milliseconds.</param>
        /// <exception cref="TimeoutException"></exception>
        /// <returns></returns>
        public static async Task WaitWhile(Func<bool> condition, int frequency = 25, int timeout = -1)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (condition())
            {
                if (timeout > 0 && sw.ElapsedMilliseconds > timeout) throw new TimeoutException();
                await Task.Delay(frequency);
            }
            sw.Stop();
        }
    
        /// <summary>
        /// Blocks until condition is true or timeout occurs.
        /// </summary>
        /// <param name="condition">The break condition.</param>
        /// <param name="frequency">The frequency at which the condition will be checked.</param>
        /// <param name="timeout">The timeout in milliseconds.</param>
        /// <returns></returns>
        public static async Task WaitUntil(Func<bool> condition, int frequency = 25, int timeout = -1)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (!condition())
            {
                if (timeout > 0 && sw.ElapsedMilliseconds > timeout) throw new TimeoutException();
                await Task.Delay(frequency);
            }
            sw.Stop();
        }
    }
