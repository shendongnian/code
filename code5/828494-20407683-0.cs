    protected void Page_Load(object sender, EventArgs e)
    {
        // Only bind your gridview with all items, if this is the first page load
        if(!Page.IsPostBack) {
            GridView1.DataSource = GetListOfAs();
            GridView1.DataBind();
            ddl.DataSource = GetListOfChoices();
            ddl.DataTextField = "name";
            ddl.DataValueField = "attribute";
            ddl.DataBind();
    
            if (ddl.Items.Count > 0)
            {
                ddl.Items.Insert(0, "Select one");
                ddl.Items[0].Value = "";
                ddl.SelectedIndex = 0;
            }
        }    
    }
        
