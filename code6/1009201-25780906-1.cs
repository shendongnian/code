    protected void Page_Load(object sender, EventArgs e)
    {
    	if (Session["name"] != null)	//this is you have to do at every postback
    	{
    		myDataTable = Session["name"] as DataTable;
    	}
    	
    	if (!IsPostBack)
    	{
    		//if it is not post back, create a new DataTable and add values to it
    		myDataTable = new DataTable();
    		myDataTable.Columns.Add("username");
    		myDataTable.Columns.Add("firstname");
    		myDataTable.Columns.Add("lastname");
    		myDataTable.Columns.Add("password");
    		myDataTable.Columns.Add("conpassword");
    		myDataTable.Columns.Add("email");
    
    		myDataTable.Rows.Add("kavi1", "kavi", "rajan", "123456", "123456", "kavi@gmail.com");
    		myDataTable.Rows.Add("sri1", "sri", "prem", "123456", "123456", "sri@gmail.com");
    		myDataTable.Rows.Add("mani1", "mani", "vanan", "123456", "123456", "mani@gmail.com");
    		HttpContext.Current.Session["name"] = myDataTable;
    	}
    }
