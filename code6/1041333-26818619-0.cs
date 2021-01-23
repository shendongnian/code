    protected void Page_PreRender(object sender,EventArgs e)
    {
        MyDiv.Attributes["onclick"] =
            ClientScript.GetPostBackEventReference(this, "MyDiv_Click");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack && Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "MyDiv_Click")
        {
            MyDiv_Click();
        }
    }
