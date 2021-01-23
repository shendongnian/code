    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GridView_DataBind();
        }
    
        private void GridView_DataBind()
        {
            string[] datasource = { "1", "2", "3" };
    
            GridView1.DataSource = datasource;
            GridView1.DataBind();
        }
    
        protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((Control)sender).NamingContainer;
            //your code here
        }
