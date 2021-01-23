        long dateL = 13928550480000;
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime date = start.AddMilliseconds(dateL/10).ToLocalTime();
                                             //    ***
                                             //     ^------
        var dtstr1 = date.ToString("MM/dd/yyyy");  // 02/19/2014
        
