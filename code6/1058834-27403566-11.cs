    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dd = dealerDetails();
    	// if more than one row is expected you can use the for loop
    	// if not, just access them directly.
    	for (int i = 0; i < d.Rows.Count - 1; i++)
    	{
            // Jump straight to here if you are positive you will only 
            // return 1 row of data.
    		string ColumnName1 = dd.Rows[i]["ColumnName1"].ToString();
    		string ColumnName2 = dd.Rows[i]["ColumnName2"].ToString();
    	}
    }
