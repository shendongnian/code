    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           this.GridSortDirection= "ASC";// setting default value 
        }
    }
