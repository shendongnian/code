    public class MyController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult BottomUpForecast()
        {
            return View(this.GetMyViewModel());
        }
        private MyViewModel GetMyViewModel()
        {
            var viewModel = new MyViewModel()
            {
                Years = this.facade.GetFinancialYears();
                Quarters = this.facade.GetFinancialQuarters();
                SelectedYear = DateTime.Now.Year;
                SelectedQuarter = this.facade.TimePeriods.GetQuarterNoForDate(DateTime.Now);
                Collection = this.facade.GetMonthlyCollection(SelectedYear, SelectedQuarter);
            }
            
            return viewModel;
        }
    }
    // Thin ViewModel
    public class MyViewModel
    {
        public IEnumerable<SomeModel> Collection { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> Quarters { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedQuarter { get; set; }
    }
