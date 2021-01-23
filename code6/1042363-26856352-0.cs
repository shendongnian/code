    public IEnumerable<Tuple<TimeSpan, bool>> GetTestPeriods()
    {
        TimeSpan preTestTime = TimeSpan.FromSeconds(5);
        TimeSpan testTime = TimeSpan.FromSeconds(3);
        TimeSpan interTestTime = TimeSpan.FromSeconds(2);
    
        yield return Tuple.Create(preTestTime, false);
        while(true)
        {
            yield return Tuple.Create(testTime, true);
            yield return Tuple.Create(interTestTime, false);
        }
    }
