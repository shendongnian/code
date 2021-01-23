     while (startDate.Year <= DateTime.Now.Year)
                {
                    //here you will get every new month in  year
                    Console.WriteLine(startDate.Month);
                    //Add Month
                    startDate=startDate.AddMonths(1);
    
                   
                }
