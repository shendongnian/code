    public static double GetNumOfOverLappingDays(DateRange b, DateRange p)
    {
       DateRange overlap = b.Intersect(p);
       if (overlap == null)
           return 0;
    
       return overlap.Span.TotalDays;
    }
