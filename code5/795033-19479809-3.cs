        class YourClass
    {
    private System.Threading.Timer timer;
    public YourClass()
    {
        timer = new System.Threading.Timer(
        _TimerTick,
        null,
        1000 * 30 * 60,
        Timeout.Infinite);
    }
    //...
    }
