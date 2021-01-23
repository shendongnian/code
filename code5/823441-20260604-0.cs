    protected override void OnInit(EventArgs e)
    {
        if ((string.IsNullOrEmpty(Session["ProgramID"].ToString())) && 
            (string.IsNullOrEmpty(Session["UserID"].ToString())) && 
            (string.IsNullOrEmpty(Session["CompanyID"].ToString())) && 
            (string.IsNullOrEmpty(Session["LanguageID"].ToString())))
        {
            Response.Redirect("SessionExpire.aspx", false);
        }
        base.OnInit(e);
    }
