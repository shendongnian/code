    protected void Page_Load(object sender, EventArgs e)
    {
        string gs = ConfigurationManager.ConnectionStrings["ging"].ConnectionString;
    }
    public bool showCheck(string strID)
    {
        string strCheckIfParentExist = @"";
    
        using (SqlConnection scConn = new SqlConnection(gs))
        {
            scConn.Open(); //throws an error: 'The ConnectionString property has not been initialized'
        }
    }
