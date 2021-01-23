    public static Timer Create(TimerCallback callback)
    {
        Timer t = null;
        t = new Timer(_ => callback(t), null, Timeout.Infinite, Timeout.Infinite);
        return t;
    }
