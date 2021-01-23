    if (!Page.IsPostBack)
    {
        if (Session["Count"] == null)
        {
            sessionCount = 0;
        }
        else
        {
            sessionCount = Convert.ToInt32(Session["Count"]);
        }
    }
