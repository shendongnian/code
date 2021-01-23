    using System;
    using System.Web;
    using System.Web.SessionState;
    
    public class AuthenticationUtilities
    	{
    	public static void CheckLogin(HttpSessionState session)
    		{
    		if (session["UserName"]==null || session["UserName"]=="") //switched to use String function to check for null or empty
    			{
    			HttpContext.Current.Response.Redirect("Account/Login.aspx");
    			}
    		}
    	}
