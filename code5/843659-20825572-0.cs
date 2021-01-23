    protected void Page_Load(object sender, EventArgs e)
    {
        //Gridview1.DataBind(); Remove it
        if (!Page.IsPostBack)
        {
            SetInitialRow();
        }
    
        ...
    
    }
