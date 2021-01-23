    public void addSecure(int value)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string values = "";
        lock (padLock)
        {
            // Save the current timer value here
            TimeSpan elapsedToAcquireLock = sw.Elapsed;
            try
            {
                if (array == null)
                {
                    this.size = 1;
                    Resize(this.size);
                    array[0] = value;
                    count++;
                }
                else
                {
                    count++;
                    if (size == count)
                    {
                        size *= 2;
                        Resize(size);
                    }
                    array[count - 1] = value;
                }
            }
            catch
            {
                throw new System.ArgumentException("It was impossible to insert, try again later.", "insert");
            }
            sw.Stop();
            values = string.Format(
                "Element {0}, Time taken: for lock acquire: {1}ms, for append operation: {2}ms",
                 value.ToString(),
                 elapsedToAcquireLock.TotalMilliseconds,
                 sw.Elapsed.TotalMilliseconds - elapsedToAcquireLock.TotalMilliseconds);
            saveFile(values);
        }
    }
