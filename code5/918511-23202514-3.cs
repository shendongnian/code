    public interface IEXFacade
    {
       public IEnumerable<SomeModel> GetMonthlyCollection(int SelectedYear, int SelectedQuarter);
       public IEnumerable<SelectListItem> GetFinancialYears();
       public IEnumerable<SelectListItem> GetFinancialQuarters();
       public int getSelectedYear();
       public int getSelectedQuarter(DateTime dateTime);
    }
