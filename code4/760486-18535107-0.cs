    var result =  (from item in db.tbl_dppITHr
                  where item.ProductionHour >= StartShift 
                        && item.ProductionHour <= EndDate
                  select new 
                       {
                         SumMachineTotal = item.MachineTotal, 
                         SumMachineClock = item.MachineClock
                       }).FirstOrDefault();
    
    if(result != null)
    {
       Console.WriteLine("Machine Total Sum: {0}" , result.SumMachineTotal);
       Console.WriteLine("Machine Clock Sum: {0}" , result.SumMachineClock);
    }
