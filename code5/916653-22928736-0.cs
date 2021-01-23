    protected void Page_Load(object sender, EventArgs e)
    
    {
    
    if (!IsPostBack)
    
    {
    
    PopulateData();//This is your table data method 
    
    }
    
    }
    
    protected void ChangePage(object sender, GridViewPageEventArgs e)
    
    {
    
    GridView1.PageIndex = e.NewPageIndex;
    
    this.PopulateData();
    
    }
