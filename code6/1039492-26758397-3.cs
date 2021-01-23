    int fileYear = int.Parse(fileName.Substring(0,4));
    int fileMonth = int.Parse(fileName.Substring(5,2));
    DateTime fileDate = new DateTime(fileYear, fileMonth, 1).AddMonths(1).AddDays(-1);
    DateTime oldestDate = DateTime.Now.AddMonths(-18);
    if(fileDate.Date >= oldestDate.Date)
    {
        // This file is within 18 months.
    }
