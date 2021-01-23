    protected void Page_Load(object sender, EventArgs e)
    {
        sp = Request.QueryString["sp"];
        param1 = Request.QueryString["param1"];
        param2 = Request.QueryString["param2"];
        param3 = Request.QueryString["param3"];
        SqlDataSource1.SelectCommand = sp;
        if (param1 != null)
        {
            SqlDataSource1.SelectParameters.Add("param1", param1);
        }
        if (param2 != null)
        {
            SqlDataSource1.SelectParameters.Add("param2", param2);
        }
        if (param3 != null)
        {
            SqlDataSource1.SelectParameters.Add("param3", param3);
        }
    }
