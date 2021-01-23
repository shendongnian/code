    private const int DefaultInterval = 40000;
    private int interval = DefaultInterval;
    ...
    
    while (dr.Read())
    {
        if (someCondition)
        {
            // do some work
            timer.Change(DefaultInterval, DefaultInterval); // revert to 40 seconds 
        }
        else 
        {
            // no change? increase polling by 10 seconds
            interval += 10000;
            timer.Change(interval, interval);
        }
    }
