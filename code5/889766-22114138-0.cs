    public partial class home : System.Web.UI.Page
    {
        List<DateTime?> Holidays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(ViewState["Holidays"] != null)
                Holidays = ViewState["Holidays"] as List<DateTime?>;
            else
                Holidays = new List<DateTime?>();
        }
        protected void btnAddHoliday_Click(object sender, EventArgs e)
        {
            if (txtOthrHoliday.Text != String.Empty)
            {
                Holidays.Add(DateTime.ParseExact(txtOthrHoliday.Text,extOtherHoliday.Format, null));
                ViewState["Holidays"] = Holidays;
            }
       }
    }
