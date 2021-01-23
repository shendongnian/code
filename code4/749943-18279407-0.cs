            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!Stopped)
            {
                // Loop here. 
                // Received Event handler is capturing messages.
                // Wait 30ms between commands
                if (stopWatch.ElapsedMilliseconds >= 33)
                {
                    lock (lockObject)
                    {
                        // Write 
                        byte[] _buffer = { byte1, byte2, byte2 };
                        WriteBuffer(_buffer);
                    }
                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
