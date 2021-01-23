    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Insert / Update data of sql data table
    
       BindData();
    }
