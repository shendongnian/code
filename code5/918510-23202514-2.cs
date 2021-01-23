    public class MyViewModel
    {
         MyViewModel(IEXFacade facade)
         {
            Years = facade.GetFinancialYears();
            Quarters = facade.GetFinancialQuarters();
            SelectedYear = facade.getSelectedYear();
            SelectedQuarter = facade.getSelectedQuarter (DateTime.Now);
            Collection = facade.GetMonthlyCollection(SelectedYear, SelectedQuarter);
        }
    
    
        //Keeping the Facade Object seems extraneous (unless I'm missing something)
        //private Facade _Facade;
        public IEnumerable<SomeModel> Collection { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> Quarters { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedQuarter { get; set; }
    }
