    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)HttpContext.Current.Session["System"] == "sysA")
        {
            gvSystemB.Visible = false;
        }
        else
        {
            gvSystemA.Visible = false;
        }
    }
