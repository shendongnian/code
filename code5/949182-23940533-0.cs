    private TimeSpan time
    
    public void setMs(long ms)
    {
        this.time = TimeSpan.FromMilliseconds(ms);
    }
    
    public long getMs()
    {
        return this.time.TotalMilliseconds;
    }
