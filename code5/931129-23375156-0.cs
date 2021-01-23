    var now = DateTime.Now;
    DateTime first = new DateTime(now.Year,now.Month,now.Day, 17, 30, 0);
    DateTime second;
    if (now.Day == DateTime.DaysInMonth(now.Year, now.Month))
    {
         if(DateTime.Now.Month == 12)
               second = new DateTime(now.Year+1, 1, 1, 5, 30, 0);
          else
               second = new DateTime(now.Year, now.Month+1, 1, 5, 30, 0);
    }
    else
    {
        second = new DateTime(now.Year, now.Month, now.Day+1, 5, 30, 0);
    }
    RadDateTimePicker1.SelectedDate = first;
    RadDateTimePicker2.SelectedDate = second;
