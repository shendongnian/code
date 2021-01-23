    public void YourMethod()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(1);
        Process(timeSpan, IsExactlyOneSecond);
        Process(timeSpan, IsMoreThanOneSecond);
    }
