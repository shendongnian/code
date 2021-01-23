    public static long compareDate(string Asso_End_Date)
    {
    DateTime date1 = DateTime.Parse(Asso_End_Date);
    DateTime date2 = DateTime.Now;
    long result;
    result = date2.Date.CompareTo(date1.Date);
    return(result)
    }
