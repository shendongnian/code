    var pageHandler = HttpContext.Current.CurrentHandler;
    if (pageHandler  is  System.Web.UI.Page)
    {
      ((System.Web.UI.Page)pageHandler).Master.FindControl("...").Visible=false;
    }
     
