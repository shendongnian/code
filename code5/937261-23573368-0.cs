    using(enumerator.CreateTimeoutScope(TimeSpan.FromHours(1)))
    {
        while(true)
        {
            if(enumerator.MoveNext())
            {
                 //process the message here
            }
        }
    }
