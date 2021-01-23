    DateTime endDate = DateTime.Now;
    double remainingAmountOfWorkingDays = Math.Round(260d / 8d);
    while (remainingAmountOfWorkingDays > 0)
      {
        endDate = endDate.AddDays(1);
                    
        if (endDate.DayOfWeek == DayOfWeek.Saturday || endDate.DayOfWeek == DayOfWeek.Sunday)
           continue;
    
        Console.WriteLine(remainingAmountOfWorkingDays +" "+endDate.ToString("dddd dd.MM.yyyy"));
        remainingAmountOfWorkingDays--;
      }           
