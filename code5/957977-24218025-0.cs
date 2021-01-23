    public Time2(int h = 0, int m = 0, int s = 0)
    {
        Console.Log("this constructor is called");
        SetTime(h, m, s);
    }
    public Time2(Time2 time)
        : this(time.hour, time.Minute, time.Second) 
    {
        Console.Log("and then this constructor is called after");
    }
