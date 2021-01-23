    List<List<DateTime>> sessions = new List<List<DateTime>> { new List<DateTime>() };
    foreach(DateTime dt in dates)
    {
        if(!sessions.Last().Any())
            sessions.Last().Add(dt);
        else
        {
            TimeSpan diff = dt - sessions.Last().Last();
            if (diff.TotalSeconds > 20)
                sessions.Add(new List<DateTime> { dt });
            else
                sessions.Last().Add(dt);
        }
    }
