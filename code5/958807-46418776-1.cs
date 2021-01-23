    PersianCalendar pc = new PersianCalendar();            
       
    var today = pc.GetDayOfMonth(DateTime.Now);
    var firstDayOfMonth = pc.GetDayOfMonth(DateTime.Now.AddDays(-(today-1)));
    var lastDayOfMonth = pc.GetDayOfMonth(DateTime.Now.AddMonths(1).AddDays(-today));            
    Console.WriteLine("First day "+ firstDayOfMonth);
    Console.WriteLine("Last day " + lastDayOfMonth);
