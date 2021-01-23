    public static void MyCallback(object delay)
    {
        Thread.Sleep(((TimeSpan)delay).TotalMilliseconds);
        ... code ...
    }
