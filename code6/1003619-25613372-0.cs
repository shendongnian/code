    if (!IsPostBack)
    {
        SetupSession();
        newpopfiles();
    }
    else
    {
        DataTable filedata = Session["varFiles"] as DataTable;
        if (filedata != null)
        {
            //... do something
        }
    }
