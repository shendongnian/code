     DateTime one =  new DateTime(2006, 06, 16),  two = new DateTime(2007, 08, 23);
     if (two > one)
     {
         int firstMonth = one.Month;
         int secondMonth = two.Month + 12 * (two.Year - one.Year);
         
         var months = new List<string>();
         for (int i = firstMonth; i <= secondMonth; i++)
         {
            months.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((i -1) % 12 + 1));
         }
      }
