    private System.Threading.Timer _timer;
    void main()
    {
        _timer = new Timer(TimerTick, null, 1000, 1000);
        // do other stuff in your main thread
    }
    void TimerTick(object state)
    {
        // do stuff here
    }
