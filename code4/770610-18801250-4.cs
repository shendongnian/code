    using (OleDbConnection con = new OleDbConnection(constr))
    using (OleDbCommand com = new OleDbCommand("select * from quant_level1", con))
    {
    	con.Open();
    	using (OleDbDataReader myReader = com.ExecuteReader())
    	{
    		DataTable dt = new DataTable();
    		dt.Load(myReader);
    		int count = dt.Rows.Count;
    	}
    }
