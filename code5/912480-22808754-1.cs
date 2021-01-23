    private static void Main(string[] args)
    {
        int year = 2014;
        int month = 3;
        int dayofweek = 3;
        int weekofmonth = 2;
        DateTime date = GetDateTime(year, month, dayofweek, weekofmonth);
        Console.WriteLine(date.ToShortDateString());
        DateTime date2 = GetDateTime(year, month, 1, 1);
        Console.WriteLine(date2.ToShortDateString());
        DateTime date3 = GetDateTime(year, month, 7, 6);
        Console.WriteLine(date3.ToShortDateString());
           
        Console.ReadLine();
    }
