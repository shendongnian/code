    static DateTime RoundToNearestInterval(DateTime dt, TimeSpan d)
    {
       int f=0;
       double m = (double)(dt.Ticks % d.Ticks) / d.Ticks;
       if (m >= 0.5)
           f=1;            
       return new DateTime(((dt.Ticks/ d.Ticks)+f) * d.Ticks);
    }
