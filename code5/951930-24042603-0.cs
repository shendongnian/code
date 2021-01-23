     protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            Response.Write("id is ");
            Label1.Text = id;
        } 
    }
