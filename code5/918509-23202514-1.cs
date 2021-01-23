    public class EXFacade : IEXFacade
    {
       private TimePeriods _timePeriods = new TimePeriods();
       public int getSelectedYear()
       {
           return DateTime.Now.Year;
       }
       public int getSelectedQuarter (DateTime dateTime)
       {
           return _timePeriods.GetQuarterNoForDate(dateTime);
       }
       public IEnumerable<SomeModel> GetMonthlyCollection
       {
               ....
               return MonthlyCollection;
       }
       public IEnumerable<SelectListItem> GetFinancialYears;
       {
               ....
               return MonthlyCollection;
       }
       public IEnumerable<SelectListItem> GetFinancialQuarters;
       {
               ....
               return MonthlyCollection;
       }
    }
