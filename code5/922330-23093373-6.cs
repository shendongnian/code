    public bool IsExactlyOneSecond(TimeSpan timeSpan)
    {
        return timeSpan.TotalSeconds == 1.0;
    }
    public bool IsMoreThanOneSecond(TimeSpan timeSpan)
    {
        return timeSpan.TotalSeconds > 1.0;
    }
