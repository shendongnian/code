    RecurringJob.AddOrUpdate(
        () => Console.WriteLine("Transparent!"), 
        Cron.Hourly(0));
    
    RecurringJob.AddOrUpdate(
        () => Console.WriteLine("Transparent!"), 
        Cron.Hourly(15));
    
    RecurringJob.AddOrUpdate(
        () => Console.WriteLine("Transparent!"), 
        Cron.Hourly(30));
    
    RecurringJob.AddOrUpdate(
        () => Console.WriteLine("Transparent!"), 
        Cron.Hourly(45));
