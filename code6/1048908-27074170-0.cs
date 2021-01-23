        private void Block()
        {
            var first = DateTime.UtcNow;
            while (_retrievalsSinceLastReset >= _rateLimit &&
               _lastReset.Add(_rateLimitSpan) > first)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(10));
                first = DateTime.UtcNow;
            }
            var second = DateTime.UtcNow;
            if (second > _lastReset.Add(_rateLimitSpan))
            {
                _lastReset = DateTime.UtcNow;
                _retrievalsSinceLastReset = 0;
            }
            if (first == second)
            {
                Console.WriteLine("DateTime.UtcNow returned same value");
            }
        }
