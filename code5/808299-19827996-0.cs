    if(!Page.IsPostback)
    {
       string[] parity = conData.GetParity();
                ddlParity.DataSource = parity.ToList();
                ddlParity.DataBind();
    }
