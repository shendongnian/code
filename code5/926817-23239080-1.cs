    var listDates = GetDates(new DateTime(2014, 3, 14), new DateTime(2014, 6, 14), "Day").ToList();
 
       public IEnumerable<DateTime> GetDates(DateTime from, DateTime to,string type)
        {
            switch (type)
            {
                case "Month":
                    {
                       for (var dt = from.AddMonths(1); dt <= to; dt=dt.AddMonths(1))
                       {
                          yield return dt;
                       }
                        break;
                    }
                case "Day":
                    {
                        for (var dt = from.AddDays(1); dt <= to; dt = dt.AddDays(1))
                        {
                            yield return dt;
                        }
                        break;
                    }
            }
            
        }
