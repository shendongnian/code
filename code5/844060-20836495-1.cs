    DateTime d1 = new DateTime(2013,12,1),
                d2 = new DateTime(2013,12,14),
                d3 = new DateTime(2013,12,10),
                d4 = new DateTime(2013,12,20);
    int count = 0;
    for (var d = d1.Date; d <= d2.Date; d = d.AddDays(1))
    {
          if (d >= d3.Date && d <= d4.Date)
               count++;
    }
    Console.WriteLine(count);
