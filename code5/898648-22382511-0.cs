    public void BindMyData()
    {
        // Do data bindings on all bound controls
    }
    public void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
            BindMyData();
    }
    public void myClick(object sender, EventArgs e)
    {
        // Update the data in the repository
        BindMyData();
    }
