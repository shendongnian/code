    public void Write(T value)
    {
        // locks are full barriers
        lock (write)
        {
            ++version;             // ++version odd: write in progress
            Thread.MemoryBarrier();
            this.value = value;
            Thread.MemoryBarrier();
            ++version;             // ++version even: write complete
        }
    }
