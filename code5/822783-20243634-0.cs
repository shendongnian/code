    private DataTable _suppliers;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
    	     string sqlQuery = "SELECT EmployeeID, Weight, Amount, EmployeeName FROM Supplier";           
    	     var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["inventoryConnectionString"].ConnectionString);
    	     _suppliers = new DataTable();
    	     var SDA = new SqlDataAdapter(sqlQuery);
    	     SDA.Fill(_suppliers);
        }
    }
    
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    	DataView DV = new DataView(_suppliers);
    	DV.RowFilter = string.Format("EmployeeName LIKE '%{0}%'", TextBox2.Text);
    	
    	if (DV.Count == 1)
    	{
    		var row = DV[0];
    		txtBoxId.Text = row["EmployeeID"].ToString();
            txtboxw.Text = row["Weight"].ToString();
            txtboxam.Text = row["Amount"].ToString();
    	}
    }
