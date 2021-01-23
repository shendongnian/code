    while (startDate <= DateTime.Now)
                {
                    //here you will get every new month in  year
                    Console.WriteLine(startDate.Month);
                    //Add Month
                    startDate=startDate.AddMonths(1);
                }
