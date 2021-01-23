    var startDate = new DateTime(2014, 2, 20);
    var endDate = new DateTime(2014, 3, 10);
    
    var days = (endDate - startDate).TotalDays;
    
    Console.WriteLine("<tr>");
    for(int i = 0; i <= days; i++)
    {
       var theDate = startDate.AddDays(i);
       Console.WriteLine("<th>{0}</th>", theDate.DayOfWeek);
    }
    Console.WriteLine("</tr>");
