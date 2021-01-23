    public partial class medical_specialties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("T");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + time + "');", true);
    		if(<<LOCATION>> IS WHITE PLAINS) {	//pseudo code, change it for your need
    			if(now.DayOfWeek == DayOfWeek.Monday){
    				if(IsTimeOfDayBetween(now, new TimeSpan(7, 0, 0), new TimeSpan(19, 30, 0) )) {
    					//show this image
    				} else {
    					//show the other image
    				}
    			} else if(now.DayOfWeek == DayOfWeek.Tuesday) {
    				..... //just go on like the example above
    			}
    		}
        }
    }
