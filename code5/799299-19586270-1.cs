    public TimeSpan periodOfService
           {
               get
               {
                    //DateOfJoin-->which i get from my database
                   DateTime  JoinDate   = Convert.ToDateTime(DateOfJoin);
                   DateTime TodayData =  DateTime.Now;
    
                   TimeSpan servicePeriod = TodayData - JoinDate;
    
                   return servicePeriod;
               }
       }
