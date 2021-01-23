    var pageHandler = HttpContext.Current.CurrentHandler;
    Control ctrl = ((System.Web.UI.Page)pageHandler).Master.FindControl("ContentPlaceHolder1").FindControl(strControlIDToBind);
    DropDownList ddl = (DropDownList)((System.Web.UI.Page)pageHandler).Master.FindControl("ContentPlaceHolder1").FindControl(strControlIDToBind);
    ddl.DataSource = read;
    ddl.DataBind();
