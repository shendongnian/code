    protected void Page_Load(object sender, EventArgs e)
    {    
        if (GridView1.Rows.Count > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv','" + GridView1.ClientID +  "', 'HeaderDiv');</script>");
        }
    }
    protected void cmdClick_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv','" + GridView1.ClientID + "', 'HeaderDiv');</script>");
    }
