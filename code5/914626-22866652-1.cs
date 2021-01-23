    public static void Show(string message, string lpRedirectPage) 
    {                
       string cleanMessage = MessageToDisplay.Replace("'", "\'");                               
       Page page = HttpContext.Current.CurrentHandler as Page; 
       string script = string.Format("alert('{0}');", cleanMessage);
       script += " window.location.href='" + lpRedirectPage+ "';"
       if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert")) 
       {
           page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
       } 
    } 
