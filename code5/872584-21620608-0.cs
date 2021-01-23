    protected void Page_Load(object sender, EventArgs e)
    {
        Add.Click += (source, e1) =>
        {
            Session["count"] = Convert.ToInt32(Session["count"]??0) + 1;
            Response.Write(Session["count"].ToString()); 
        };
    }
