    static bool Between(DateTime one, DateTime two)
    {
        var currentDate = DateTime.Now;
        if (currentDate <= two && currentDate >= one)
            return true;
        return false;
    }
    static bool Between(TimeSpan one, TimeSpan two)
    {
        var currentDate = DateTime.Now;
        DateTime dt1= new DateTime(one.Ticks);
        DateTime dt2 = new DateTime(two.Ticks);
        return Between(dt1, dt2)
    }
