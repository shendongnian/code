    public static class PersonTimeSheetExtensions
    {
        public static IEnumerable<MonthWorked> ToMonthWorked(this PersonTimeSheet personTimeSheet)
        {
            yield return
                new MonthWorked
                    {
                        Date = new DateTime(personTimeSheet.Year, 1, 0),
                        Name = personTimeSheet.Name,
                        HoursWorked = personTimeSheet.Jan
                    };
    
            yield return
                new MonthWorked
                {
                    Date = new DateTime(personTimeSheet.Year, 2, 0),
                    Name = personTimeSheet.Name,
                    HoursWorked = personTimeSheet.Feb
                 };
    
                yield return
                    new MonthWorked
                    {
                        Date = new DateTime(personTimeSheet.Year, 3, 0),
                        Name = personTimeSheet.Name,
                        HoursWorked = personTimeSheet.March
                    };
    
                yield return
                    new MonthWorked
                    {
                        Date = new DateTime(personTimeSheet.Year, 4, 0),
                        Name = personTimeSheet.Name,
                        HoursWorked = personTimeSheet.April
                    };
    
                yield return
                    new MonthWorked
                    {
                        Date = new DateTime(personTimeSheet.Year, 5, 0),
                        Name = personTimeSheet.Name,
                        HoursWorked = personTimeSheet.May
                    };
    
                //...
            }
        }
