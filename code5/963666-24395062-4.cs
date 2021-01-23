    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                this.ViewBag.RecordNum = 1;
                this.ViewBag.MonthList = this.GetMonthList();
                this.ViewBag.YearList = this.GetYearList();
                return PartialView();
            }
    
            private IEnumerable<SelectListItem> GetYearList()
            {
                List<SelectListItem> yearList = new List<SelectListItem>();
                int current_yr = Convert.ToInt32(DateTime.Now.Year.ToString());
                int select_yr = 0;
                for (int i = (current_yr - 3); i <= current_yr; i++)
                {
                    select_yr = current_yr - (i - (current_yr - 3));
                    yearList.Add(new SelectListItem() { Value = select_yr.ToString(), Text = select_yr.ToString() });
                }
                return yearList;
            }
    
            private IEnumerable<SelectListItem> GetMonthList()
            {
                List<SelectListItem> monthList = new List<SelectListItem>();
                monthList.Add(new SelectListItem() { Value = "JAN", Text = "Jan" });
                monthList.Add(new SelectListItem() { Value = "FEB", Text = "Feb" });
                monthList.Add(new SelectListItem() { Value = "MAR", Text = "Mar" });
                monthList.Add(new SelectListItem() { Value = "APR", Text = "Apr" });
                monthList.Add(new SelectListItem() { Value = "MAY", Text = "May" });
                monthList.Add(new SelectListItem() { Value = "JUN", Text = "Jun" });
                monthList.Add(new SelectListItem() { Value = "JUL", Text = "Jul" });
                monthList.Add(new SelectListItem() { Value = "AUG", Text = "Aug" });
                monthList.Add(new SelectListItem() { Value = "SEP", Text = "Sep" });
                monthList.Add(new SelectListItem() { Value = "OCT", Text = "Oct" });
                monthList.Add(new SelectListItem() { Value = "NOV", Text = "Nov" });
                monthList.Add(new SelectListItem() { Value = "DEC", Text = "Dec" });
                return monthList;
            }
    
        }
    }
