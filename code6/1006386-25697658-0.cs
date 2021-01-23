    public class Set
    {
    	 public string setSession()
        {
            HttpContext.Current.Session["User_ID"] = "shubhadeepchat@gmail.com";
            return HttpContext.Current.Session["User_ID"].ToString();
        }
    }
