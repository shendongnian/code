    public partial class medical_specialties : System.Web.UI.Page
    {
    	String url1 = "theImages/ClosedHeaderMiddle.png";
    	String url2 = "theImages/OpenHeaderMiddle.png";
    	String location1URL = "";	//White Plains
    	String location2URL = "";	//Rye
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("T");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + time + "');", true);
            
                if(now.DayOfWeek == DayOfWeek.Monday){
                    if(IsTimeOfDayBetween(now, new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0) )) {
                        location1URL = url2;
    					location2URL = url1;
                    } else if(IsTimeOfDayBetween(now, new TimeSpan(8, 0, 0), new TimeSpan(17, 30, 0)) {
                        location1URL = url2;
    					location2URL = url2;
                    } else if(IsTimeOfDayBetween(now, new TimeSpan(17, 30, 0), new TimeSpan(19, 30, 0)) {
                        location1URL = url2;
    					location2URL = url1;
                    } else {
    					location1URL = url1;
    					location2URL = url1;
    				}
                } else if(now.DayOfWeek == DayOfWeek.Tuesday) {
                    ..... //just go on like the example above
                }
            
        }
    }
    
