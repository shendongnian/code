    var p=HttpContext.Current.CurrentHandler;
    if (p is  System.Web.UI.Page)
    {
      ((System.Web.UI.Page)p).Master.FindControl("...").Visible=false;
    }
     
