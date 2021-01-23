     DateTime dt = DateTime.Now.AddDays(-(DateTime.Now.Day - 1));
     int lday= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
     DateTime DTY = new DateTime(DateTime.Now.Year, DateTime.Now.Month, lday);
          
     MessageBox.Show("First Day :- "+dt.DayOfWeek.ToString());
     MessageBox.Show("Last Day :-" + DTY.DayOfWeek.ToString());
