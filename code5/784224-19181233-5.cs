    for 
    (
        DateTime date = new DateTime(2012, 08, 01).AddMonths(1);
        date <= new DateTime(2013, 03, 01);
        date = date.AddMonths(1)
    )
    {
        Console.WriteLine(date.ToString("MM/yyyy"));
    }
