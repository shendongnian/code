    void Main()
    {
        var birthdays = new List<DateTime>();
    	birthdays.Add(new DateTime(2013, 11, 08));
    	birthdays.Add(new DateTime(2012, 05, 05));
    	birthdays.Add(new DateTime(2014, 05, 05));
    	birthdays.Add(new DateTime(2005, 11, 08));
    	
    	DateTime twoDaysAgo = DateTime.Now.AddDays(-2);
        DateTime MonthAway = DateTime.Now.AddDays(30);
    
        var bdays = from p in birthdays where p.DayOfYear > twoDaysAgo.DayOfYear &&
                         p.DayOfYear < MonthAway.DayOfYear
                         orderby p 
                         select p;
        Console.WriteLine (bdays);
    }
