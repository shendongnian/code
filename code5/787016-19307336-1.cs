    namespace Temp
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    _year.DataSource = GetData.getYear();
                    _year.DataTextField = "Year";
                    _year.DataBind();
                    _month.Items.Add(new ListItem("Select"));
                    _month.DataBind();
                    _day.Items.Add(new ListItem("Select"));
                    _day.DataBind();
                }
            }
            protected void _year_SelectedIndexChanged(object sender, EventArgs e)
            {
                _month.Items.Clear();
                _month.DataSource = GetData.getMonth();
                _month.DataTextField = "MonthName";
                _month.DataValueField = "MonthId";
                _month.DataBind();
            }
            protected void _month_SelectedIndexChanged(object sender, EventArgs e)
            {
                _day.Items.Clear();
                _day.DataSource = GetData.getDays(_month.SelectedIndex+1,GetData.isLeapYear(Convert.ToInt32(_year.SelectedValue)));
                _day.DataTextField = "Day";
                _day.DataBind();
            }
            protected void _day_SelectedIndexChanged(object sender, EventArgs e)
            {
               //Use selected value of _month _year and _day here
            }
        }    
        public class GetData
        {
            public static List<day> getDays(int monthId,bool isLeapYear)
            {
                int maxLimit;
                if (monthId == 2)
                {
                    if (isLeapYear) maxLimit = 29;
                    else maxLimit = 28;
                }
                else if (monthId == 1 || monthId == 3 || monthId == 5 || monthId == 7 || monthId == 8 || monthId == 10 || monthId == 12)
                    maxLimit = 31;
                else maxLimit = 30;
                List<day> days = new List<day>();
                for (int i = 1; i <= maxLimit; i++)
                {
                    days.Add(new day { Day = i });
                }
                return days;
    
            }
            public static List<year> getYear()
            {
                //Set here min and max range of year 
                int minLimit = 1950;
                int maxLimit = DateTime.Now.Year;
                List<year> years = new List<year>();
                for (int i = minLimit; i <= maxLimit; i++)
                {
                    //You can modify code for bind year dropdown 
                    //respectively change in date or month
                    /*if (isLeapYear)
                    {
                        if(i%4==0)
                            years.Add(new year { Year = i });
                    }
                    else*/
                    years.Add(new year { Year = i });
                }
                return years;
            }
            public static List<month> getMonth()
            {
                List<month> months=new List<month>();            
                months.Add(new month { MonthId = 1, MonthName = "Jan" });
                months.Add(new month { MonthId = 2, MonthName = "Frb" }); months.Add(new month { MonthId = 3, MonthName = "Mar" });
                months.Add(new month { MonthId = 4, MonthName = "Apr" }); months.Add(new month { MonthId = 5, MonthName = "May" });
                months.Add(new month { MonthId = 6, MonthName = "Jun" }); months.Add(new month { MonthId = 7, MonthName = "July" }); 
                months.Add(new month { MonthId = 8, MonthName = "Aug" });
                months.Add(new month { MonthId = 9, MonthName = "Sep" }); months.Add(new month { MonthId = 10, MonthName = "Oct" });
                months.Add(new month { MonthId = 11, MonthName = "Nov" });months.Add(new month { MonthId = 12, MonthName = "Dec" });
                return months;
            }
            internal static bool isLeapYear(int p)
            {
                if (p % 4 == 0)
                    return true;
                else return false;
            }
        }
        public class month
        {
            public string MonthName { get; set; }
            public int MonthId { get; set; }
        }
        public class day
        {
            public int Day { get; set; }
        }
        public class year
        {
            public int Year { get; set; }
        }
    }
