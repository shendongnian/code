    if (e.CommandName == "divCom")
    {
        WebControl wc = e.CommandSource as WebControl;
        GridViewRow row = wc.NamingContainer as GridViewRow;
        HtmlGenericControl P_div = (HtmlGenericControl)row.FindControl("p_div");
        P_div.Visible = true;
    }
    else
    {
        WebControl wc = e.CommandSource as WebControl;
        GridViewRow row = wc.NamingContainer as GridViewRow;
        HtmlGenericControl P_div = (HtmlGenericControl)row.FindControl("p_div");
        P_div.Visible = false;
    }
