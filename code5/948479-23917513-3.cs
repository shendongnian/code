    using System;
    using System.Web;
    
    public class AuthenticationUtilities
    	{
    	public static void CheckLogin()
    		{
    		if (HttpContext.Current.Session["UserName"]==null || HttpContext.Current.Session["UserName"]=="")
    			{
    			HttpContext.Current.Response.Redirect("Account/Login.aspx");
    			}
    		}
    	}
