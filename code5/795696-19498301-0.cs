    bool IsYesterday(DateTime dt)
    {
        DateTime yesterday = DateTime.Today.AddDays(-1);
        if (dt >= yesterday && dt < DateTime.Today)
            return true;
        return false;
    }
    
    bool IsInLastMonth(DateTime dt)
    {
        DateTime lastMonth = DateTime.Today.AddMonths(-1);
        return dt.Month == lastMonth.Month && dt.Year == lastMonth.Year;
    }
    
    bool IsInLastYear(DateTime dt)
    {
        return dt.Year == DateTime.Now.Year - 1;
    }
