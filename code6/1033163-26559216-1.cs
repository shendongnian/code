    public partial class WebForm1 : System.Web.UI.Page
    {
        bool clear = true;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //if we are here, the date actually changed, so set clear to false
            clear = false;
        }
        protected void Calendar1_PreRender(object sender, EventArgs e)
        {
            //if clear is true and the event target is the calendar and a date was clicked
            if (clear  
                && !string.IsNullOrEmpty(Request.Form["__EVENTTARGET"])
                && Request["__EVENTTARGET"].Contains(Calendar1.ID)
                && char.IsDigit(Request.Form["__EVENTARGUMENT"][0]))
            {
                Calendar1.SelectedDates.Clear(); //clear the date
            }
        }
 
    }
