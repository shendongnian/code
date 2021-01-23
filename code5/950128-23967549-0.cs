    public class MyPage : Page
    {
        protected override void OnLoad(EventArgs e)
    	{
    		base.OnLoad(e);
    		if(Session["User"] == null) 
                    {
                          Response.Redirect("/login.aspx");
                    }
    	}
    }
