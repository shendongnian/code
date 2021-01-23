    if (gvAccess.Rows[0].ItemArray[0].toString() == "0")
    {
        gvAccess.Visible=false;
    }
    else
    {
        Button1.Visible=false;
        RhombusL.Visible=false;
        Permission.Visible=false;
        EmailL.Visible=false;
        Email.Visible=false;
        SiteL.Visible=false;
        Site.Visible=false;
        RhombusPerErr.Visible=false;
        Enter.Text="This user already has access at your centre.";
        gvAccess.Visible=false;
    }
