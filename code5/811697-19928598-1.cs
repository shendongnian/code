     try 
        {
        }
        catch (System.Threading.ThreadAbortException ex)
        {
        }
        For Response.End : Invoke  HttpContext.Current.ApplicationInstance.CompleteRequest    method instead of Response.End to bypass the code execution to the Application_EndRequest event
        For Response.Redirect : Use an overload, Response.Redirect(String url, bool endResponse) that passes false for endResponse parameter to suppress the internal call to Response.End
   -------------------------
    	
    // code that follows Response.Redirect is executed
    Response.Redirect ("mynextpage.aspx", false);
    For Server.Transfer : Use Server.Execute method to bypass abort. When Server.Execute is used, execution of code happens on the new page, post which the control returns to the initial page, just after where it was called
