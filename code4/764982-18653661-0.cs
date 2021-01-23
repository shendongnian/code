        List<string> MonthNames(DateTime date1, DateTime date2)
        {
            var monthList = new List<string>();
            while (date1 < date2)
            {
                monthList.Add(date1.ToString("MMMM/yyyy"));
                date1 = date1.AddMonths(1);
            }
            return monthList;
        }
