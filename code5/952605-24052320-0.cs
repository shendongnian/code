    var groupped = cusDate.OrderBy(x => x.Date)
        .GroupBy(x => x.Month);
    foreach (var item in groupped)
    {
        Console.WriteLine("Key:{0}", item.Key);
        foreach (var cd in item)
        {
            Console.WriteLine("Date:{0}, Day:{1}, Month:{2}", cd.Date, cd.Day, cd.Month);
        }
    }
