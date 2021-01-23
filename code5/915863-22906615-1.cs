    var startDate = new DateTime(2014, 4, 22);
    var endDate = new DateTime(2014, 4, 25);
    var sb = new StringBuilder();
    while (startDate <= endDate)
    {
        sb.AppendFormat("|{0}", startDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)); 
        startDate = startDate.AddDays(1);
    }
    Console.WriteLine(sb.ToString().Substring(1));
