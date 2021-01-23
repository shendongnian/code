    if (!string.IsNullOrEmpty(Request.QueryString["name"]))
    {
        nameSpan.InnerHtml = Request.QueryString["name"].ToString();
    }
    else
    {
        nameSpan.Visible = false;
    }
