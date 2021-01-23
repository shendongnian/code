            public static string GetBase36Timestamp()
            {
                string result;
                lock (_lastValue)
                {
                    do
                    {
                        // _sw is a running Stopwatch; Microseconds = ticks / 10
                        long microseconds = EpochToStopwatchStart().Add(_sw.Elapsed).Ticks / 10L;
                        result = MicrosecondsToBase36(microseconds);
                    } while (result == _lastValue);
                }
                return result;
            }
