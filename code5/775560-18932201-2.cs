    public string functionname(arg)
    {
        if (condition)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            page.ClientScript.RegisterStartupScript(
                typeof(Page),
                "Test",
                "<script type='text/javascript'>functionname1(" + arg1 + ",'" + arg2 + "');</script>");
        }
    }
