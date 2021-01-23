    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = 
        System.Configuration.ConfigurationManager.ConnectionStrings["name"].ConnectionString;
    
        if(!string.IsNullOrEmpty(connectionString))
        {
             //Use it here...
             SqlDataSource1.ConnectionString = connectionString;
        }
    }
