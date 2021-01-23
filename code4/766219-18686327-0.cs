    protected void Page_Load(object sender, EventArgs e)
    {
        WebControl myControl = (WebControl)LoadControl("~/Controls/webControl");
        myControl.ABCMethod();
    }
