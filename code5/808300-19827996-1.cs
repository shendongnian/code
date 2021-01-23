    if(!Page.IsPostBack)
    {
       string[] parity = conData.GetParity();
                ddlParity.DataSource = parity.ToList();
                ddlParity.DataBind();
    }
