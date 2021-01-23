    private void Process(TimeSpan timeSpan, Predicate<TimeSpan> test)
    {
        if (test(timeSpan))
        {
            // Do something
        }
    }
